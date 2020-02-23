using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        //public string ReadVideoTitle() //original
        // public string ReadVideoTitle(IFileReader fileReader) //passing by method parameter
        //public IFileReader FileReader{ get; set; }

        // need a constructor to use the FileReader property
        //public VideoService()

        //consturtor parameter
        //**problem with this is have changed signature of the contructor, so will break code using it

        private IFileReader _fileReader;

        //by adding this overloading constructor, no longer have broken code due to signature change
        //public VideoService()
        //{
        //    _fileReader = new FileReader();
        //}
        //public VideoService (IFileReader fileReader)
        //{
        //    _fileReader = fileReader;
        //}


        //finally, can combine the two above into a single constructor , by making the IFileReader optional by adding '= null'

        //not a good dependency injection
        //public VideoService(IFileReader fileReader = null)
        //{
        //    //if fileReader is not null, then use file reader, else if is null, then will create a new fileReader.  This may not be ideal in enterprise solutions.  Want to use proper dependency injection.  Want your dependency injection to take care of creating and initializing objects.
        //    _fileReader = fileReader ?? new FileReader();
        //}

          //good dependency injection with constructor should look like this
            public VideoService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public string ReadVideoTitle()

        {
            // ** 1. Move this code into another class
            //var str = File.ReadAllText("video.txt");

            // **2. Turn this into an interface
            //var str = new FileReader().Read("video.txt");

            // ** 3 ways to pass instance of a class that implements IFileReader
            // this is dependency injection
            // 1) pass as a method parameter
            // 2) pass as a property
            //      sometimes the framework will not work well with changing to accept a parameter, so then use properties
            // 3) pass by a constructive parameter
            // some dependency injection frameworks cannot use properties. So can inject by constructor parameters

            //var str = fileReader.Read("video.txt"); //removing the new and making this call loosely coupled and testable since can now pass a fake file reader object

            var str = _fileReader.Read("video.txt"); //this implements the interface as a property . this needs a constructor
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            using (var context = new VideoContext())
            {
                var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();
                
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}