﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace catch_kill_signal
{
    public class WinExitSignal : IExitSignal
    {
        public event EventHandler Exit;

        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        // A delegate type to be used as the handler routine
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        /// <summary>
        /// Need this as a member variable to avoid it being garbage collected.
        /// </summary>
        private HandlerRoutine m_hr;

        public WinExitSignal()
        {
            m_hr = new HandlerRoutine(ConsoleCtrlCheck);

            SetConsoleCtrlHandler(m_hr, true);

        }

        /// <summary>
        /// Handle the ctrl types
        /// </summary>
        /// <param name="ctrlType"></param>
        /// <returns></returns>
        private bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_C_EVENT:
                    Console.WriteLine($"{DateTime.Now} CtrlTypes.CTRL_C_EVENT");
                    break;
                case CtrlTypes.CTRL_BREAK_EVENT:
                    Console.WriteLine($"{DateTime.Now} CtrlTypes.CTRL_BREAK_EVENT");
                    break;
                case CtrlTypes.CTRL_CLOSE_EVENT:
                    Console.WriteLine($"{DateTime.Now} CtrlTypes.CTRL_CLOSE_EVENT");
                    break;
                case CtrlTypes.CTRL_LOGOFF_EVENT:
                    Console.WriteLine($"{DateTime.Now} CtrlTypes.CTRL_LOGOFF_EVENT");
                    break;
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    Console.WriteLine($"{DateTime.Now} CtrlTypes.CTRL_SHUTDOWN_EVENT");
                    break;
                default:
                    break;
            }
            //Environment.Exit(0);
            while (true)
            {

                
                Console.WriteLine($"{DateTime.Now} waiting for real kill");
                Thread.Sleep(500);
                
            }

            return true;
        }


    }
}
