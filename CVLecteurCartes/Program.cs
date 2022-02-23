using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        /// <summary>
        /// Struct representing a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        enum VirtualKeyStates : int
        {
            NONE = 0,
            //
            VK_LBUTTON = 0x01,
            VK_RBUTTON = 0x02,
            VK_CANCEL = 0x03,
            VK_MBUTTON = 0x04,
            //
            VK_XBUTTON1 = 0x05,
            VK_XBUTTON2 = 0x06,
            //
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            //
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            //
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_PAUSE = 0x13,
            VK_CAPITAL = 0x14,
            //
            VK_KANA = 0x15,
            VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
            VK_HANGUL = 0x15,
            VK_JUNJA = 0x17,
            VK_FINAL = 0x18,
            VK_HANJA = 0x19,
            VK_KANJI = 0x19,
            //
            VK_ESCAPE = 0x1B,
            //
            VK_CONVERT = 0x1C,
            VK_NONCONVERT = 0x1D,
            VK_ACCEPT = 0x1E,
            VK_MODECHANGE = 0x1F,
            //
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            //
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_APPS = 0x5D,
            //
            VK_SLEEP = 0x5F,
            //
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            //
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            //
            VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
                                       //
            VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
            VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
            VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
            VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
            VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
                                     //
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            //
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWARD = 0xA7,
            VK_BROWSER_REFRESH = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORITES = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            //
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRACK = 0xB0,
            VK_MEDIA_PREV_TRACK = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAUSE = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_SELECT = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            //
            VK_OEM_1 = 0xBA,   // ';:' for US
            VK_OEM_PLUS = 0xBB,   // '+' any country
            VK_OEM_COMMA = 0xBC,   // ',' any country
            VK_OEM_MINUS = 0xBD,   // '-' any country
            VK_OEM_PERIOD = 0xBE,   // '.' any country
            VK_OEM_2 = 0xBF,   // '/?' for US
            VK_OEM_3 = 0xC0,   // '`~' for US
                               //
            VK_OEM_4 = 0xDB,  //  '[{' for US
            VK_OEM_5 = 0xDC,  //  '\|' for US
            VK_OEM_6 = 0xDD,  //  ']}' for US
            VK_OEM_7 = 0xDE,  //  ''"' for US
            VK_OEM_8 = 0xDF,
            //
            VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            VK_ICO_HELP = 0xE3,  //  Help key on ICO
            VK_ICO_00 = 0xE4,  //  00 key on ICO
                               //
            VK_PROCESSKEY = 0xE5,
            //
            VK_ICO_CLEAR = 0xE6,
            //
            VK_PACKET = 0xE7,
            //
            VK_OEM_RESET = 0xE9,
            VK_OEM_JUMP = 0xEA,
            VK_OEM_PA1 = 0xEB,
            VK_OEM_PA2 = 0xEC,
            VK_OEM_PA3 = 0xED,
            VK_OEM_WSCTRL = 0xEE,
            VK_OEM_CUSEL = 0xEF,
            VK_OEM_ATTN = 0xF0,
            VK_OEM_FINISH = 0xF1,
            VK_OEM_COPY = 0xF2,
            VK_OEM_AUTO = 0xF3,
            VK_OEM_ENLW = 0xF4,
            VK_OEM_BACKTAB = 0xF5,
            //
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE,
            //
            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4A,
            K = 0x4B,
            L = 0x4C,
            M = 0x4D,
            N = 0x4E,
            O = 0x4F,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5A
        }
        [DllImport("user32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);
        /*
            private const int KEY_PRESSED = 0x8000;
            public bool IsPressed(){
            return Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_LBUTTON) & KEY_PRESSED);
        */

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Appuie  de la  touche
        public const int KEYEVENTF_KEYUP = 0x0002; //Relachement  de la  touche

        /*
        VK_NUMPAD7	0x67	VK_BACK	0x08
        VK_NUMPAD8	0x68	VK_TAB	0x09
        VK_NUMPAD9	0x69	VK_RETURN	0x0D
        VK_MULTIPLY	0x6A	VK_SHIFT	0x10
        VK_ADD	0x6B	VK_CONTROL	0x11
        VK_SEPARATOR	0x6C	VK_MENU	0x12
        VK_SUBTRACT	0x6D	VK_PAUSE	0x13
        VK_DECIMAL	0x6E	VK_CAPITAL	0x14
        VK_DIVIDE	0x6F	VK_ESCAPE	0x1B
        VK_F1	0x70	VK_SPACE	0x20
        VK_F2	0x71	VK_END	0x23
        VK_F3	0x72	VK_HOME	0x24
        VK_F4	0x73	VK_LEFT	0x25
        VK_F5	0x74	VK_UP	0x26
        VK_F6	0x75	VK_RIGHT	0x27
        VK_F7	0x76	VK_DOWN	0x28
        VK_F8	0x77	VK_PRINT	0x2A
        VK_F9	0x78	VK_SNAPSHOT	0x2C
        VK_F10	0x79	VK_INSERT	0x2D
        VK_F11	0x7A	VK_DELETE	0x2E
        VK_F12	0x7B	VK_LWIN	0x5B
        VK_NUMLOCK	0x90	VK_RWIN	0x5C
        VK_SCROLL	0x91	VK_NUMPAD0	0x60
        VK_LSHIFT	0xA0	VK_NUMPAD1	0x61
        VK_RSHIFT	0xA1	VK_NUMPAD2	0x62
        VK_LCONTROL	0xA2	VK_NUMPAD3	0x63
        VK_RCONTROL	0xA3	VK_NUMPAD4	0x64
        VK_LMENU	0xA4	VK_NUMPAD5	0x65
        VK_RMENU	0xA5	VK_NUMPAD6	0x66
        */

        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        //Use the values of this enum for the 'dwData' parameter
        //to specify an X button when using MouseEventFlags.XDOWN or
        //MouseEventFlags.XUP for the dwFlags parameter.
        public enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);


        // Je crée ma fonction qui va appuyer sur les touches

        public static void PressKeys()
        {

            System.Threading.Thread.Sleep(5000);


            // APPUIE DE LA TOUCHE A

            keybd_event((int)VirtualKeyStates.A, 0, KEYEVENTF_EXTENDEDKEY, 0); //appuie 
            keybd_event((int)VirtualKeyStates.A, 0, KEYEVENTF_KEYUP, 0); //relache

            // PAUSE (temps en miliseconde)
            System.Threading.Thread.Sleep(1000);

            // APPUIE DE LA TOUCHE B
            keybd_event((int)VirtualKeyStates.B, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((int)VirtualKeyStates.B, 0, KEYEVENTF_KEYUP, 0);


            System.Threading.Thread.Sleep(1000);


            // APPUIE DE LA TOUCHE C
            keybd_event((int)VirtualKeyStates.C, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((int)VirtualKeyStates.C, 0, KEYEVENTF_KEYUP, 0);


            System.Threading.Thread.Sleep(1000);


            // APPUIE DE LA TOUCHE D
            keybd_event((int)VirtualKeyStates.D, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event((int)VirtualKeyStates.D, 0, KEYEVENTF_KEYUP, 0);


        }
        // Et j’appelle ma fonction ou bon me semble

        static private void ancienMode()
        {
            Console.WriteLine("Hello !");
            string param;
            int h = -1, m = -1;
            do
            {
                param = Console.ReadLine();
                if (param == string.Empty)
                {
                    Random rnd = new Random();
                    h = 1 + rnd.Next(2);
                    m = rnd.Next(60);
                }
                else
                {
                    int idx = param.IndexOf('h');
                    if (idx > 0)
                    {
                        string s = param.Substring(0, idx);
                        for (int i = s.Length - 1; i >= 0; --i)
                            if (s[i] < '0' || '9' < s[i])
                            {
                                s = s.Substring(i + 1);
                                break;
                            }
                        h = int.Parse(s);
                    }
                    idx = param.IndexOf('m');
                    if (idx > 0)
                    {
                        string s = param.Substring(0, idx);
                        for (int i = s.Length - 1; i >= 0; --i)
                            if (s[i] < '0' || '9' < s[i])
                            {
                                s = s.Substring(i + 1);
                                break;
                            }
                        m = int.Parse(s);
                    }
                }
            }
            while ((h < 0 || h > 24) || (m < 0 || m > 60));

            Console.WriteLine(h + ":" + m);
            for (int i = 5; i > 0; --i)
            {
                Console.WriteLine("Warning !");
                System.Threading.Thread.Sleep(1000);
            }

            //keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, 0); //appuie 
            //keybd_event(L, 0, KEYEVENTF_EXTENDEDKEY, 0); //appuie 
            //keybd_event(L, 0, KEYEVENTF_KEYUP, 0); //relache
            //keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0); //relache

            // Simulating a Alt+Tab keystroke
            //keybd_event(VK_MENU, 0xb8, 0, 0); //Alt Press
            //keybd_event(VK_TAB, 0x8f, 0, 0); // Tab Press
            //keybd_event(VK_TAB, 0x8f, KEYEVENTF_KEYUP, 0); // Tab Release
            //keybd_event(VK_MENU, 0xb8, KEYEVENTF_KEYUP, 0); // Alt Release

            //System.Threading.Thread.Sleep(2000);

            // Simulating a Ctrl+A keystroke
            //keybd_event(VK_CONTROL, 0x9d, 0, 0); // Ctrl Press
            //keybd_event(A, 0x9e, 0, 0); // ‘A’ Press
            //keybd_event(A, 0x9e, KEYEVENTF_KEYUP, 0); // ‘A’ Release
            //keybd_event(VK_CONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release

            //keybd_event(VK_LMENU, 0x9d, 0, 0); // LWin Press
            //keybd_event(L, 0x9e, 0, 0); // ‘L’ Press
            //keybd_event(L, 0x9e, KEYEVENTF_KEYUP, 0); // ‘L’ Release
            //keybd_event(VK_LMENU, 0x9d, KEYEVENTF_KEYUP, 0); // LWin Release

            /*DateTime date = DateTime.Now;
            TimeSpan sp = new TimeSpan(0, 43, 0);
            while (sp.CompareTo(DateTime.Now - date) > 0)
            {
                keybd_event((int)VirtualKeyStates.VK_CONTROL, 0x9d, 0, 0); // Ctrl Press
                System.Threading.Thread.Sleep(500 + new Random().Next(1000));
                keybd_event((int)VirtualKeyStates.VK_CONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release
                System.Threading.Thread.Sleep(1000 + new Random().Next(4000));
            }*/

            //mouse_event((int)MouseEventFlags.MOVE, 50, 50, 0, 0);
            //System.Threading.Thread.Sleep(100);
            //mouse_event((int)MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(100);
            //mouse_event((int)MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
            //System.Threading.Thread.Sleep(2000);

            //POINT lpPoint;
            //GetCursorPos(out lpPoint);
            //
            //while (true)
            //{
            //    GetCursorPos(out lpPoint);
            //    Console.WriteLine("x:" + lpPoint.X + " y:" + lpPoint.Y);
            //    System.Threading.Thread.Sleep(1000);
            //}

            /*if (dx >= 0) udx = dx;
            else udx = dx;*/
            //mouse_event((int)MouseEventFlags.MOVE, (uint)(500 - lpPoint.X), (uint)(500 - lpPoint.Y), 0, 0);

            //VirtualKeyStates randK = (VirtualKeyStates)Enum.ToObject(typeof(VirtualKeyStates), 'A' + (new Random().Next('Z' - 'A')));
            //Console.WriteLine("Go for " + randK + " !");
            IEnumerable<VirtualKeyStates> lstVKeys = Enum.GetValues(typeof(VirtualKeyStates)).Cast<VirtualKeyStates>();

            int pixTh = 10;
            TimeSpan sp = new TimeSpan(h, m, 0);
            DateTime date = DateTime.Now;
            POINT lpPoint, lpPoint2;
            GetCursorPos(out lpPoint);
            while (sp.CompareTo(DateTime.Now - date) > 0)
            {
                keybd_event((int)VirtualKeyStates.VK_LCONTROL, 0x9d, 0, 0); // Ctrl Press
                System.Threading.Thread.Sleep(500 + new Random().Next(1000));
                GetCursorPos(out lpPoint2);
                /*if (Math.Abs(lpPoint2.X - lpPoint.X) > pixTh || Math.Abs(lpPoint2.Y - lpPoint.Y) > pixTh ||
                    (lstVKeys.FirstOrDefault(v => v != VirtualKeyStates.VK_CONTROL && v != VirtualKeyStates.VK_LCONTROL && GetKeyState(v) < 0)) != VirtualKeyStates.NONE)
                {
                    keybd_event((int)VirtualKeyStates.VK_LCONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release
                    break;
                }*/
                keybd_event((int)VirtualKeyStates.VK_LCONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release
                System.Threading.Thread.Sleep(1000 + new Random().Next(4000));
                GetCursorPos(out lpPoint2);
                //if (Math.Abs(lpPoint2.X - lpPoint.X) > pixTh || Math.Abs(lpPoint2.Y - lpPoint.Y) > pixTh) break;
                //if ((lstVKeys.FirstOrDefault(v => v != VirtualKeyStates.VK_CONTROL && v != VirtualKeyStates.VK_LCONTROL && GetKeyState(v) < 0)) != VirtualKeyStates.NONE) break;
            }
        }

        private static void nouveauMode(string[] args)
        {
            for(int i = 0; i< args.Length;++i)
            {
                string cmd = args[i].Trim();
                Console.WriteLine(cmd);
                try
                {
                    char etat = cmd[0];
                    cmd = cmd.Substring(2).Trim();
                    string[] splt = cmd.Split('h');
                    int h = int.Parse(splt[0]);
                    int m = int.Parse(splt[1]);
                    DateTime now = DateTime.Now;
                    DateTime dtFin = new DateTime(now.Year, now.Month, now.Day, h, m, 0);
                    int minRndD, MagRndD;
                    int minRndU, MagRndU;
                    if (etat=='P')
                    {
                        minRndD = 500; MagRndD = 1000;
                        minRndU = 1000; MagRndU = 10000;
                    }
                    else //if (etat=='A')
                    {
                        minRndD = 500; MagRndD = 1000;
                        minRndU = 900000; MagRndU = 300000;
                    }
                    while (TimeSpan.Zero.CompareTo(dtFin - DateTime.Now) <= 0)
                    {
                        TimeSpan tsp = (dtFin - DateTime.Now);
                        int TTms = Math.Max((int)tsp.TotalMilliseconds, 0);
                        keybd_event((int)VirtualKeyStates.VK_LCONTROL, 0x9d, 0, 0); // Ctrl Press
                        System.Threading.Thread.Sleep(Math.Min(minRndD + new Random().Next(MagRndD), TTms));

                        keybd_event((int)VirtualKeyStates.VK_LCONTROL, 0x9d, KEYEVENTF_KEYUP, 0); // Ctrl Release
                        System.Threading.Thread.Sleep(Math.Min(minRndU + new Random().Next(MagRndU), TTms));
                    }
                }
                catch { }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 0) ancienMode();
            else nouveauMode(args);

            //if (GetKeyState(randK) >= 0) LockWorkStation();
            //Console.WriteLine("Bye!");
            System.Threading.Thread.Sleep(4000);
        }
    }
}
