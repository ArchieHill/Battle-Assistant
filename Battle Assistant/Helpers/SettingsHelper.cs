﻿// SettingsHelper.cs
//
// Copyright (c) 2022 Archie Hill
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;

namespace Battle_Assistant.Helpers
{
    /// <summary>
    /// Settings Helper - Saves and loads settings
    /// </summary>
    public static class SettingsHelper
    {
        private static readonly ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private const string THEME_SETTING = "theme";

        private const string WIDTH_SETTING = "width";
        private const string HEIGHT_SETTING = "height";
        private const string WINDOW_SIZE_SETTING = "windowSize";

        private const string X_POSITION_SETTING = "X";
        private const string Y_POSITION_SETTING = "Y";
        private const string WINDOW_POSITION_SETTING = "position";

        /// <summary>
        /// Saves the theme
        /// </summary>
        /// <param name="theme">The theme string</param>
        public static void SaveTheme(string theme)
        {
            localSettings.Values[THEME_SETTING] = theme;
        }

        /// <summary>
        /// Saves the window size
        /// </summary>
        /// <param name="width">The window width</param>
        /// <param name="height">The window height</param>
        public static void SaveWindowSize(int width, int height)
        {
            ApplicationDataCompositeValue windowSize = new ApplicationDataCompositeValue();
            windowSize[WIDTH_SETTING] = width;
            windowSize[HEIGHT_SETTING] = height;
            localSettings.Values[WINDOW_SIZE_SETTING] = windowSize;
        }

        /// <summary>
        /// Saves the window position
        /// </summary>
        /// <param name="x">The windows x position</param>
        /// <param name="y">The windows y position</param>
        public static void SaveWindowPosition(int x, int y)
        {
            ApplicationDataCompositeValue windowPosition = new ApplicationDataCompositeValue();
            windowPosition[X_POSITION_SETTING] = x;
            windowPosition[Y_POSITION_SETTING] = y;
            localSettings.Values[WINDOW_POSITION_SETTING] = windowPosition;
        }

        /// <summary>
        /// Loads all the settings, used at application start
        /// </summary>
        public static void LoadSettings()
        {
            //Sets the application theme
            string theme = (string)localSettings.Values[THEME_SETTING];
            if (theme != null)
            {
                (App.MainWindow.Content as Grid).RequestedTheme = EnumHelper.GetEnum<ElementTheme>(theme);
            }

            //Sets the application window size
            ApplicationDataCompositeValue windowSize = (ApplicationDataCompositeValue)localSettings.Values[WINDOW_SIZE_SETTING];
            if (windowSize != null)
            {
                int width = (int)windowSize[WIDTH_SETTING];
                int height = (int)windowSize[HEIGHT_SETTING];
                App.SetWindowSize(width, height);
            }

            //Sets the application window position
            ApplicationDataCompositeValue windowPosition = (ApplicationDataCompositeValue)localSettings.Values[WINDOW_POSITION_SETTING];
            if (windowPosition != null)
            {
                int x = (int)windowPosition[X_POSITION_SETTING];
                int y = (int)windowPosition[Y_POSITION_SETTING];
                App.SetWindowPosition(x, y);
            }
        }


    }
}
