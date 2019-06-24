using System;
using System.ComponentModel;
using System.Drawing;           // NOTE: Project + Add Reference required
using System.Windows.Forms;     // NOTE: Project + Add Reference required
using System.Runtime.InteropServices;

namespace Project_Euler
{

     /// I did not write this class myself (well, the implementing method, but not the gears) -
     /// all credit goes to Hans Passant:
     /// https://stackoverflow.com/questions/2888824/console-setwindowposition-centered-each-and-every-time
     public static class ConsoleUtils
     {
          public static void CenterConsole()
          {
               IntPtr hWin = GetConsoleWindow();
               RECT rc;
               GetWindowRect(hWin, out rc);
               Screen scr = Screen.FromPoint(new Point(rc.left, rc.top));
               int x = scr.WorkingArea.Left + (scr.WorkingArea.Width - (rc.right - rc.left)) / 2;
               int y = scr.WorkingArea.Top + (scr.WorkingArea.Height - (rc.bottom - rc.top)) / 2;
               MoveWindow(hWin, x, y, rc.right - rc.left, rc.bottom - rc.top, false);
          }

          // P/Invoke declarations
          private struct RECT { public int left, top, right, bottom; }
          [DllImport("kernel32.dll", SetLastError = true)]
          private static extern IntPtr GetConsoleWindow();
          [DllImport("user32.dll", SetLastError = true)]
          private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);
          [DllImport("user32.dll", SetLastError = true)]
          private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);

          /// <summary>
          /// Adjusts console window size & centers the window on the screen.
          /// Parameters allow the adjustment of window size in relation to possible max size.
          /// Parameters left blank maximizes and centers windows.
          /// </summary>
          /// <param name="widthEdge">Number of horizontal units that the window is made *less* than max.</param>
          /// <param name="heightEdge">Number of vertical lines that the window is made *less* than max.</param>
          public static void WindowAdjust(int widthEdge = 0, int heightEdge = 0)
          {
               int width = Console.LargestWindowWidth - widthEdge; // a rather random reduction of window size for aethetic purposes
               int height = Console.LargestWindowHeight - heightEdge;

               Console.SetWindowSize(width, height);
               CenterConsole();
          }
     }

}