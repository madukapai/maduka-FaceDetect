using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace FaceDetect_EmguCV
{
    public class WebCam : IDisposable
    {
        /* Those contants are used to overload the unmanaged code functions
         * each constant represent a state*/

        private const short WM_CAP = 0x400;
        private const int WM_CAP_DRIVER_CONNECT = 0x40a;
        private const int WM_CAP_DRIVER_DISCONNECT = 0x40b;
        private const int WM_CAP_EDIT_COPY = 0x41e;
        private const int WM_CAP_SET_PREVIEW = 0x432;
        private const int WM_CAP_SET_OVERLAY = 0x433;
        private const int WM_CAP_SET_PREVIEWRATE = 0x434;
        private const int WM_CAP_SET_SCALE = 0x435;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const short SWP_NOMOVE = 0x2;
        private short SWP_NOZORDER = 0x4;
        private short HWND_BOTTOM = 1;

        //This function enables enumerate the web cam devices
        [DllImport("avicap32.dll")]
        protected static extern bool capGetDriverDescriptionA(short wDriverIndex,
            [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName,
           int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);

        //This function enables create a  window child with so that you can display it in a picturebox for example
        [DllImport("avicap32.dll")]
        protected static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string
    lpszWindowName,
            int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        //This function enables set changes to the size, position, and Z order of a child window
        [DllImport("user32")]
        protected static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        //This function enables send the specified message to a window or windows
        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object
    lParam);

        //This function enable destroy the window child 
        [DllImport("user32")]
        protected static extern bool DestroyWindow(int hwnd);

        // Normal device ID
        int DeviceID = 0;
        // Handle value to preview window
        int hHwnd = 0;
        //The devices list
        ArrayList ListOfDevices = new ArrayList();

        //The picture to be displayed
        public PictureBox Container { get; set; }

        // Connect to the device.
        /// <summary>
        /// This function is used to load the list of the devices 
        /// </summary>
        public void Load()
        {
            string Name = String.Empty.PadRight(100);
            string Version = String.Empty.PadRight(100);
            bool EndOfDeviceList = false;
            short index = 0;

            // Load name of all avialable devices into the lstDevices .
            do
            {
                // Get Driver name and version
                EndOfDeviceList = capGetDriverDescriptionA(index, ref Name, 100, ref Version, 100);
                // If there was a device add device name to the list
                if (EndOfDeviceList) ListOfDevices.Add(Name.Trim());
                index += 1;
            }
            while (!(EndOfDeviceList == false));
        }

        /// <summary>
        /// Function used to display the output from a video capture device, you need to create 
        /// a capture window.
        /// </summary>
        public void OpenConnection()
        {
            string DeviceIndex = Convert.ToString(DeviceID);
            IntPtr oHandle = Container.Handle;
            {
                // MessageBox.Show("You should set the container property");
            }

            // Open Preview window in picturebox .
            // Create a child window with capCreateCaptureWindowA so you can display it in a picturebox.

            hHwnd = capCreateCaptureWindowA(ref DeviceIndex, WS_VISIBLE | WS_CHILD, 0, 0, 640, 480, oHandle.ToInt32(), 0);
            // hHwnd = capCreateCaptureWindowA(ref DeviceIndex, WS_VISIBLE | WS_CHILD, 0, 0, 640, 480, oHandle.ToInt32(), 0);

            // Connect to device
            if (SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, DeviceID, 0) != 0)
            {
                // Set the preview scale
                SendMessage(hHwnd, WM_CAP_SET_SCALE, -1, 0);
                // Set the preview rate in terms of milliseconds
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0);
                // Start previewing the image from the camera
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, -1, 0);
                // Resize window to fit in picturebox
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, Container.Width, Container.Height, SWP_NOMOVE | SWP_NOZORDER);
            }
            else
            {
                // Error connecting to device close window
                DestroyWindow(hHwnd);
            }
        }
        //Close windows
        void CloseConnection()

        {
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, DeviceID, 0);
            // close window
            DestroyWindow(hHwnd);
        }

        //Save image

        public void SaveImage()
        {
            IDataObject data;
            Image oImage;
            SaveFileDialog sfdImage = new SaveFileDialog();
            sfdImage.Filter = "(*.bmp)|*.bmp";
            // Copy image to clipboard
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);

            // Get image from clipboard and convert it to a bitmap
            data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
            {
                oImage = (Image)data.GetData(typeof(System.Drawing.Bitmap));
                Container.Image = oImage;
                CloseConnection();
                if (sfdImage.ShowDialog() == DialogResult.OK)

                {
                    oImage.Save(sfdImage.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }

        public Image CaptureImage()
        {
            IDataObject data;
            Image oImage = null;
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);
            data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(Bitmap)))
                oImage = (Image)data.GetData(typeof(System.Drawing.Bitmap));
            return oImage;
        }


        /// <summary>
        /// This function is used to dispose the connection to the device
        /// </summary>
            #region IDisposable Members

        public void Dispose()

        {
            CloseConnection();
        }
        #endregion
    }
}