﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcessMash.Tools
{
    public class Hotkeys
    {
        #region Static
        /// <summary>
        /// Registers a key as a hotkey.
        /// </summary>
        /// <param name="hWnd">Window handle of a control.</param>
        /// <param name="id">Hotkey ID that will be used for messaging.</param>
        /// <param name="fsModifiers">Modifier key codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8.
        /// <para>Compute the addition of each combination of the keys you want to be pressed:</para>
        /// ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...</param>
        /// <param name="vlc">Key that should be pressed. <see cref="Keys"/> can be cast with <see cref="int"/>.</param>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        #region Constructors
        public Hotkeys(int id) 
            => ID = id;
        #endregion

        #region Properties
        public int ID { get; }
        #endregion

        #region Methods
        public bool Register(IntPtr handle, int modifiers, int key)
            => RegisterHotKey(handle, ID, modifiers, key);

        public bool Unregister(IntPtr handle)
            => UnregisterHotKey(handle, ID);
        #endregion
    }
}
