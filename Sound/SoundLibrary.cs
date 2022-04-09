using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Sound
{
    class SoundLibrary
    {
        public static List<Sound> Sounds { get; private set; }
        public static string TempFolderName = "GameJPiA2021_temp_music";
        public static Uri TempPath { get; private set; }

        /// <summary>
        /// Initializes sound library on app start. 
        /// </summary>
        /// <param name="tempFiles">Determines if copy files to temporary folder or not.</param>
        public static void InitializeLibrary(bool tempFiles)
        {
            if(Sounds == null)
            {
                Sounds = SoundLibraryGenerator.CreateLibrary();
                if (tempFiles)
                {
                    InitilizeTempraryFiles();
                }
            }
        }

        /// <summary>
        /// Copies music / sound files to OS temporary folder. 
        /// </summary>
        public static void InitilizeTempraryFiles() 
        {
            BuildTempPath();

            try
            {
                Directory.CreateDirectory(TempPath.AbsolutePath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An exception occurred: " + ex.Message + ". Sound will be disabled.");
                return;
            }

            foreach (Sound s in Sounds)
            {
                s.FilePath = new Uri(Path.Combine(TempPath.AbsolutePath, s.FileName), UriKind.Absolute);
                if (!File.Exists(s.FilePath.AbsolutePath))
                {
                    using (FileStream bytetoimage = File.Create(s.FilePath.AbsolutePath))
                    {
                        bytetoimage.Write(s.Resource, 0, s.Resource.Length);
                    }
                }
            }

            Resource1.ResourceManager.ReleaseAllResources();
        }

        /// <summary>
        /// Removes music / sound files from OS temporary folder.
        /// </summary>
        public static void DiscardTemporaryFiles() 
        {
            if(TempPath == null) { BuildTempPath(); }
            DirectoryInfo directory = new DirectoryInfo(TempPath.AbsolutePath);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
        }

        /// <summary>
        /// Creates temporary folder path to store app data. 
        /// </summary>
        private static void BuildTempPath()
        {
            TempPath = new Uri(Path.Combine(Path.GetTempPath(), TempFolderName));
        }
        
    }

    class Sound
    {
        /// <summary>
        /// Uri type path to music / sound file on hard drive. 
        /// </summary>
        public Uri FilePath { get; set; }
        /// <summary>
        /// Name of sound / music. 
        /// </summary>
        public string SoundName { get; set; }
        /// <summary>
        /// Name of file on hard drive. 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Sound context
        /// </summary>
        public SoundContext SoundContext { get; set; }
        /// <summary>
        /// Sound type
        /// </summary>
        public SoundType SoundType { get; set; }
        /// <summary>
        /// Sound byte stream resource file. 
        /// </summary>
        public byte[] Resource { get; set; }

        public Sound(Uri filePath, string soundName, string fileName, SoundContext soundContext, SoundType soundType, byte[] resource)
        {
            FilePath = filePath;
            SoundName = soundName;
            FileName = fileName;
            SoundContext = soundContext;
            SoundType = soundType;
            Resource = resource;
        }
    }

    public enum SoundContext
    {
        MenuPage,
        GamePage,
        Battle
    }

    public enum SoundType
    {
        Background,
        MouseSound,
        Player,
        MonsterInit,
        MonsterBite,
        MonsterDeath,
        MonsterWin, 
        BattleRequiredItem
    }
}
