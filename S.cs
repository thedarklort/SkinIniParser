using System;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Collections.Generic;
using IniParser.Parser;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace SkinIniParse
{
    public class SkinIniParser
    {
        private class JSONOutput
        {
            // General
            public string Name { get; set; }
            public string Author { get; set; }
            public string Version { get; set; }
            public string AnimationFramerate { get; set; }
            public string AllowSliderBallTint { get; set; }
            public string ComboBurstRandom { get; set; }
            public string CursorCentre { get; set; }
            public string CursorExpand { get; set; }
            public string CursorRotate { get; set; }
            public string CursorTrailRotate { get; set; }
            public string CustomComboBurstSounds { get; set; }
            public string HitCircleOverlayAboveNumber { get; set; }
            public string LayeredHitSounds { get; set; }
            public string SliderBallFlip { get; set; }
            public string SliderBallFrames { get; set; }
            public string SliderStyle { get; set; }
            public string SpinnerFadePlayfield { get; set; }
            public string SpinnerFrequencyModulate { get; set; }
            public string SpinnerNoBlink { get; set; }

            // Colours
            public string Combo1 { get; set; }
            public string Combo2 { get; set; }
            public string Combo3 { get; set; }
            public string Combo4 { get; set; }
            public string Combo5 { get; set; }
            public string Combo6 { get; set; }
            public string Combo7 { get; set; }
            public string Combo8 { get; set; }
            public string InputOverlayText { get; set; }
            public string MenuGlow { get; set; }
            public string SliderBall { get; set; }
            public string SliderBorder { get; set; }
            public string SliderTrackOverride { get; set; }
            public string SongSelectActiveText { get; set; }
            public string SongSelectInactiveText { get; set; }
            public string SpinnerBackground { get; set; }
            public string StarBreakAdditive { get; set; }

            // Fonts
            public string HitCirclePrefix { get; set; }
            public string HitCircleOverlap { get; set; }
            public string ScorePrefix { get; set; }
            public string ScoreOverlap { get; set; }
            public string ComboPrefix { get; set; }
            public string ComboOverlap { get; set; }
        }


        string[,] GeneralSection = new string[19, 2];
        string[,] ColoursSection = new string[17, 2];
        string[,] FontsSection = new string[6, 2];


        private void Initialize()
        {
            // General Key Names     
            GeneralSection[0, 0] = "Name";
            GeneralSection[1, 0] = "Author";
            GeneralSection[2, 0] = "Version";
            GeneralSection[3, 0] = "AnimationFramerate";
            GeneralSection[4, 0] = "AllowSliderBallTint";
            GeneralSection[5, 0] = "ComboBurstRandom";
            GeneralSection[6, 0] = "CursorCentre";
            GeneralSection[7, 0] = "CursorExpand";
            GeneralSection[8, 0] = "CursorRotate";
            GeneralSection[9, 0] = "CursorTrailRotate";
            GeneralSection[10, 0] = "CustomComboBurstSounds";
            GeneralSection[11, 0] = "HitCircleOverlayAboveNumber";
            GeneralSection[12, 0] = "LayeredHitSounds";
            GeneralSection[13, 0] = "SliderBallFlip";
            GeneralSection[14, 0] = "SliderBallFrames";
            GeneralSection[15, 0] = "SliderStyle";
            GeneralSection[16, 0] = "SpinnerFadePlayfield";
            GeneralSection[17, 0] = "SpinnerFrequencyModulate";
            GeneralSection[18, 0] = "SpinnerNoBlink";
            // General Default Values
            GeneralSection[0, 1] = "";
            GeneralSection[1, 1] = "";
            GeneralSection[2, 1] = "latest";
            GeneralSection[3, 1] = "0";
            GeneralSection[4, 1] = "0";
            GeneralSection[5, 1] = "0";
            GeneralSection[6, 1] = "1";
            GeneralSection[7, 1] = "1";
            GeneralSection[8, 1] = "1";
            GeneralSection[9, 1] = "1";
            GeneralSection[10, 1] = "";
            GeneralSection[11, 1] = "1";
            GeneralSection[12, 1] = "1";
            GeneralSection[13, 1] = "1";
            GeneralSection[14, 1] = "";
            GeneralSection[15, 1] = "2";
            GeneralSection[16, 1] = "0";
            GeneralSection[17, 1] = "1";
            GeneralSection[18, 1] = "0";

            // Colours Key Names
            ColoursSection[0, 0] = "Combo1";
            ColoursSection[1, 0] = "Combo2";
            ColoursSection[2, 0] = "Combo3";
            ColoursSection[3, 0] = "Combo4";
            ColoursSection[4, 0] = "Combo5";
            ColoursSection[5, 0] = "Combo6";
            ColoursSection[6, 0] = "Combo7";
            ColoursSection[7, 0] = "Combo8";
            ColoursSection[8, 0] = "InputOverlayText";
            ColoursSection[9, 0] = "MenuGlow";
            ColoursSection[10, 0] = "SliderBall";
            ColoursSection[11, 0] = "SliderBorder";
            ColoursSection[12, 0] = "SliderTrackOverride";
            ColoursSection[13, 0] = "SongSelectActiveText";
            ColoursSection[14, 0] = "SongSelectInactiveText";
            ColoursSection[15, 0] = "SpinnerBackground";
            ColoursSection[16, 0] = "StarBreakAdditive";
            // Colours Default Values
            ColoursSection[0, 1] = "255,192,0";
            ColoursSection[1, 1] = "0,202,0";
            ColoursSection[2, 1] = "18,124,255";
            ColoursSection[3, 1] = "242,24,57";
            ColoursSection[4, 1] = "";
            ColoursSection[5, 1] = "";
            ColoursSection[6, 1] = "";
            ColoursSection[7, 1] = "";
            ColoursSection[8, 1] = "0,0,0";
            ColoursSection[9, 1] = "0,78,155";
            ColoursSection[10, 1] = "2,170,255";
            ColoursSection[11, 1] = "255,255,255";
            ColoursSection[12, 1] = ""; // Default uses current Combo Colour
            ColoursSection[13, 1] = "0,0,0";
            ColoursSection[14, 1] = "255,255,255";
            ColoursSection[15, 1] = "100,100,100";
            ColoursSection[16, 1] = "255,182,193";

            // Fonts Key Names
            FontsSection[0, 0] = "HitCirclePrefix";
            FontsSection[1, 0] = "HitCircleOverlap";
            FontsSection[2, 0] = "ScorePrefix";
            FontsSection[3, 0] = "ScoreOverlap";
            FontsSection[4, 0] = "ComboPrefix";
            FontsSection[5, 0] = "ComboOverlap";
            // Fonts Default Values
            FontsSection[0, 1] = "default";
            FontsSection[1, 1] = "-2";
            FontsSection[2, 1] = "score";
            FontsSection[3, 1] = "-2";
            FontsSection[4, 1] = "score";
            FontsSection[5, 1] = "-2";
        }

        private string InsertInJSONClass(List<string> FinalValues)
        {
            JSONOutput JSONData = new JSONOutput();
            // General Section
            JSONData.Name = FinalValues[0];
            JSONData.Author = FinalValues[1];
            JSONData.Version = FinalValues[2];
            JSONData.AnimationFramerate = FinalValues[3];
            JSONData.AllowSliderBallTint = FinalValues[4];
            JSONData.ComboBurstRandom = FinalValues[5];
            JSONData.CursorCentre = FinalValues[6];
            JSONData.CursorExpand = FinalValues[7];
            JSONData.CursorRotate = FinalValues[8];
            JSONData.CursorTrailRotate = FinalValues[9];
            JSONData.CustomComboBurstSounds = FinalValues[10];
            JSONData.HitCircleOverlayAboveNumber = FinalValues[11];
            JSONData.LayeredHitSounds = FinalValues[12];
            JSONData.SliderBallFlip = FinalValues[13];
            JSONData.SliderBallFrames = FinalValues[14];
            JSONData.SliderStyle = FinalValues[15];
            JSONData.SpinnerFadePlayfield = FinalValues[16];
            JSONData.SpinnerFrequencyModulate = FinalValues[17];
            JSONData.SpinnerNoBlink = FinalValues[18];

            // Colours Section
            JSONData.Combo1 = FinalValues[19];
            JSONData.Combo2 = FinalValues[20];
            JSONData.Combo3 = FinalValues[21];
            JSONData.Combo4 = FinalValues[22];
            JSONData.Combo5 = FinalValues[23];
            JSONData.Combo6 = FinalValues[24];
            JSONData.Combo7 = FinalValues[25];
            JSONData.Combo8 = FinalValues[26];
            JSONData.InputOverlayText = FinalValues[27];
            JSONData.MenuGlow = FinalValues[28];
            JSONData.SliderBall = FinalValues[29];
            JSONData.SliderBorder = FinalValues[30];
            JSONData.SliderTrackOverride = FinalValues[31];
            JSONData.SongSelectActiveText = FinalValues[32];
            JSONData.SongSelectInactiveText = FinalValues[33];
            JSONData.SpinnerBackground = FinalValues[34];
            JSONData.StarBreakAdditive = FinalValues[35];

            // Fonts Section
            JSONData.HitCirclePrefix = FinalValues[36];
            JSONData.HitCircleOverlap = FinalValues[37];
            JSONData.ScorePrefix = FinalValues[38];
            JSONData.ScoreOverlap = FinalValues[39];
            JSONData.ComboPrefix = FinalValues[40];
            JSONData.ComboOverlap = FinalValues[41];


            string JSONstring = JsonConvert.SerializeObject(JSONData);

            return JSONstring;
        }

        private string ReturnDefaults()
        {
            List<string> IniValues = new List<string>();

            for (int i = 0; i < 19; i++)
            {
                IniValues.Add(GeneralSection[i, 1]);
            }

            for (int i = 0; i < 17; i++)
            {
                IniValues.Add(ColoursSection[i, 1]);
            }

            for (int i = 0; i < 6; i++)
            {
                IniValues.Add(FontsSection[i, 1]);
            }
            return InsertInJSONClass(IniValues);
        }

        private static string FormatString(string s)
        {
            int index = s.IndexOf("//");
            if (index > 0)
            {
                s = s.Substring(0, index - 2);
            }
            return s.Trim();
        }

        private string ParseFile(string Filename)
        {
            bool UseCustomComboColour = false;


            List<string> IniValues = new List<string>();
            string IniDataFile = File.ReadAllText(Filename);
            var parser = new IniDataParser();

            IniParser.Model.Configuration.IniParserConfiguration config = parser.Configuration;

            config.KeyValueAssigmentChar = Convert.ToChar(":");
            config.CommentString = "//";
            config.SkipInvalidLines = true;
            config.AllowDuplicateSections = true;
            config.AllowDuplicateKeys = true;


            IniData data = parser.Parse(IniDataFile);


            // Loop to get all General Keys
            for (int i = 0; i < 19; i++)
            {
                string s = data["General"][GeneralSection[i, 0]];
                if (s != null)
                {
                    s = FormatString(s);
                }
                else
                {
                    s = GeneralSection[i, 1];
                }

                IniValues.Add(s);
            }

            // Loop to get all Colours Keys
            for (int i = 0; i < 17; i++)
            {
                string s = data["Colours"][ColoursSection[i, 0]];

                // if Combo1 is given within Skin.ini it Ignores the Defaults for Combo2 to Combo4
                if ((i == 0) && !string.IsNullOrEmpty(s))
                {
                    UseCustomComboColour = true;
                }

                if (s != null)
                {
                    s = FormatString(s);
                }
                else
                {
                    if (i > 0 && i <= 7 && UseCustomComboColour)
                    {
                        s = "";
                    }
                    else
                    {
                        s = ColoursSection[i, 1];
                    }
                }
                IniValues.Add(s);
            }

            for (int i = 0; i < 6; i++)
            {
                string s = data["Fonts"][FontsSection[i, 0]];
                if (s != null)
                {
                    s = FormatString(s);
                }
                else
                {

                    s = FontsSection[i, 1];
                }
                IniValues.Add(s);
            }

            return InsertInJSONClass(IniValues);
        }

        public string ParseIniFile(string Filename)
        {
           
            if (!File.Exists(Filename))
            {
                Initialize();
                return ReturnDefaults();              
            }

            Initialize();

            return ParseFile(Filename);
        }
    }
}
