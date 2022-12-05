using System;
namespace Musics
{
 public static class Music
 
  { 
    public class MusicList
    {

        public int Id { get; set; }
        public string? Track { get; set; }
        public string? Artist { get; set; }
    }
        public static string name;
        public static List<MusicList> music = new();
        public static void Main(string[] args)
    {
        while (true){
             Console.WriteLine(
          "\n\n\t...................MUSIC PLAYER...................\n\n" +
            "\t\t\tWHAT WOULD YOU LIKE TO DO?\n\n" +
             "\t\tType 1 to Show Available  MusicList.\n" +
            "\t\tType 2 to Add New MusicList.\n" +
            "\t\tType 3 to Edit Available MusicList.\n"+ 
            "\t\tType 4 to Remove Available MusicList.\n"+ 
            "\t\tType 5 to Create and Show  PlayList.\n"  
             );
           int userInput = 0;
           while(!int.TryParse(Console.ReadLine(), out userInput))
            {
            Console.WriteLine("invalid input,please try again");
             }

             switch (userInput)
            {
            case 1:
                  DisplayMusic();
                break;
            case 2:
               AddMusic();
                break;
            case 3:
              EditMusic();
              break;
            case 4:
                RemoveMusic();
              break;
               case 5:
                CreatePlayList();
              break;
              default:
                  Console.WriteLine("\n Invalid Command. Please type a number from 0 to 5.\n");
              break;   
        }    
        

        }
    }
    public static List<MusicList> newList = new();

        public static int newId = 0;
          public static List<MusicList> musics = new List<MusicList>{
             new MusicList { Artist = "Celin Dion",    Id = 1, Track="Lying Down"},
            new MusicList { Artist = "Camila Cabello", Id = 2, Track="Don't Go Yet"},
            new MusicList { Artist = "Alan Walker",    Id = 3, Track="Alone"},
            new MusicList { Artist = "Kygo ft Selena Gomez", Id = 4, Track="It Ain't Me"},
        };

     static List<MusicList> FetchMusic()
        {
            return musics;
        }

           public static void DisplayMusic()
        {
            Console.Clear();

            FetchMusic().ForEach(music => Console.WriteLine($" id {music.Id} \t Track: {music.Track} \t Artist: {music.Artist}"));
        }

      public static void AddMusic()
        {
            Console.Clear();
            
                foreach (var item in FetchMusic())
                {
                    if (item.Id != newId)
                    {
                        newId = newId + 1;

                    }
                }
                bool check = true;
                 string Track;
                  string Artist; 
                while (check)
                {
                   Console.WriteLine("Add new music\n");
                 do{
                    Console.WriteLine("Enter Track name");
                    Track = Console.ReadLine();
            }
            while(Track.Any(a=>!char.IsLetter(a)));
             do{
                    Console.WriteLine("Enter  Artist name");
                    Artist = Console.ReadLine();
            }
            while(Track.Any(b=>!char.IsLetter(b)));

                    FetchMusic().Add(new MusicList { Id = newId += 1, Track = Track, Artist = Artist });
                  DisplayMusic();
                  Console.WriteLine("press 1 to add more,  any key to go main menu \n ");
                  var moremusic = Console.ReadLine();
                    if (moremusic == "1")
                    {
                        check = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }


      public static void EditMusic()
        {
            Console.Clear();
            int editId = 0;
            string Track;
            string Artist; 
            Console.WriteLine("Enter Id of music you want to edit");
           while(!int.TryParse(Console.ReadLine(), out editId))
            {
            Console.WriteLine("invalid input,please try again");
             }

              do{
                    Console.WriteLine("Enter new Track name");
                    Track = Console.ReadLine();
            }
            while(Track.Any(c=>!char.IsLetter(c)));
             do{
                    Console.WriteLine("Enter new Artist name");
                    Artist = Console.ReadLine();
            }
            while(Track.Any(d=>!char.IsLetter(d)));


                var editSong = FetchMusic().FirstOrDefault(edit => edit.Id == editId);
                if (editSong != null)
                {
                    editSong.Track = Track;
                    editSong.Artist = Artist;

                }
                Console.WriteLine("Sucessfully updated");
                DisplayMusic();

        }

      public static void RemoveMusic()
        {

            int delete = 0;
            Console.WriteLine("enter an Id to remove music from available musics");
            while(!int.TryParse(Console.ReadLine(), out delete))
            {
            Console.WriteLine("invalid input,please try again");
             }

              var matched = FetchMusic().First(d => d.Id == delete);
              FetchMusic().Remove(matched);
              DisplayMusic();
        

        }


      public static void CreatePlayList()
        {
            Console.Clear();
            
                bool check = true;
                while (check)
                {
                    Console.WriteLine("Enter playlist name");
                    string name = Console.ReadLine();

                    Console.WriteLine("{0} successfully Created", name); 
                    Console.WriteLine("Enter Id of Track to add to playlist");
                    int playListId = 0;
                    while(!int.TryParse(Console.ReadLine(), out playListId))
                    {
                      Console.WriteLine("invalid input,please try again");
                    }
                    foreach (var music in musics)
                    {
                        if (playListId == music.Id)
                        {
                            newList.Add(music);
                            newList.ForEach(newplaylist => Console.WriteLine($"{newplaylist.Id} {newplaylist.Track} {newplaylist.Artist}"));
                        }else{
                          Console.WriteLine("");
                        }
                         
                        }
                        Console.WriteLine("Playlist Name: {0}", name);
                        newList.ForEach(input => Console.WriteLine($"Track id {input.Id} Track name: {input.Track} Artist: {input.    Artist}"));
                        Console.WriteLine("press 1 to add more, press any key to go main menu \n ");
                        var moremusic = Console.ReadLine();
                    if (moremusic == "1")
                    {
                        check = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
               
       }
}



