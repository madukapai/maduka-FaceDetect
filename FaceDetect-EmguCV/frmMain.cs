using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;

namespace FaceDetect_EmguCV
{
    public partial class frmMain : Form
    {
        bool blCameraOpen = false;
        WebCam oWebCam;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            oWebCam = new WebCam();
            oWebCam.Container = picRender;
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            blCameraOpen = !blCameraOpen;

            if (blCameraOpen)
            {
                // 啟動照相機
                btnStartCamera.Text = "Stop";
                oWebCam.Container.Height = picRender.Height;
                oWebCam.Container.Width = picRender.Width;
                oWebCam.OpenConnection();
                tiCapture.Enabled = true;
            }
            else
            {
                // 停止照相機
                btnStartCamera.Text = "Start";
                oWebCam.Dispose();
                tiCapture.Enabled = false;
            }
        }

        private void tiCapture_Tick(object sender, EventArgs e)
        {
            // 截取畫面
            string strFileName = Application.StartupPath + @"\images\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            Image objImage = oWebCam.CaptureImage();
            objImage.Save(strFileName);

            Bitmap objBmp = new Bitmap(objImage);
            this.CaptureFace(strFileName);
        }

        private void CaptureFace(string strFileName)
        {
            /*
            Image<Gray, byte> depthImage = new Image<Gray, byte>(objBmp);
            // depthImage.Bytes = objImage;
            IImage image = new Mat();
            CvInvoke.BitwiseNot(depthImage, image);
            */

            IImage image;

            //Read the files as an 8-bit Bgr image  
            image = new UMat(strFileName, ImreadModes.Color); //UMat version

            //image = new Mat(strFileName, ImreadModes.Color); //CPU version

            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            DetectFace.Detect(
              image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
              faces, eyes,
              out detectionTime);

            txtMessage.Text = "";
            txtMessage.Text += JsonConvert.SerializeObject(faces);
            txtMessage.Text += JsonConvert.SerializeObject(eyes);

            // 刪除檔案
            File.Delete(strFileName);

            // 繪製框線
            // transparentControl1.DrawRectangle(faces);
        }
    }
}
