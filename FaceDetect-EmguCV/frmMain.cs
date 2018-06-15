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
using System.Threading;

namespace FaceDetect_EmguCV
{
    public partial class frmMain : Form
    {
        bool blCameraOpen = false;
        VideoCapture objVideoCapture = new VideoCapture();
        Mat objMat = new Mat();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            objVideoCapture = new VideoCapture(0);
            objVideoCapture.ImageGrabbed += ProcessFrameAsync;
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            blCameraOpen = !blCameraOpen;

            if (blCameraOpen)
            {
                // 啟動照相機
                btnStartCamera.Text = "Stop";
                objVideoCapture.Start();
            }
            else
            {
                // 停止照相機
                btnStartCamera.Text = "Start";
                objVideoCapture.Stop();
            }
        }

        /// <summary>
        /// 處理影格的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessFrameAsync(object sender, EventArgs e)
        {
            try
            {
                // 從OpenCV取得影像，並辨識人臉的存在
                objVideoCapture.Retrieve(objMat, 0);
                OpenCVResult result = this.CaptureFace(objMat);

                // 在影像上進行框線的繪圖
                for (int f = 0; f < result.faces.Count; f++)
                    CvInvoke.Rectangle(objMat, result.faces[f], new Emgu.CV.Structure.Bgr(Color.Red).MCvScalar, 2);

                for (int y = 0; y < result.eyes.Count; y++)
                    CvInvoke.Rectangle(objMat, result.eyes[y], new Emgu.CV.Structure.Bgr(Color.Yellow).MCvScalar, 1);

                // 將圖片放到PictureBox之中
                picRender.Image = objMat.Bitmap;
                System.Threading.Thread.Sleep(5);
                objVideoCapture.Dispose();
            }
            catch(Exception ex)
            {
                string strMsg = ex.Message;
                txtMessage.Text = strMsg;
            }
        }

        /// <summary>
        /// 透過OpenCV進行人臉是否存在的辨識
        /// </summary>
        /// <param name="objMat"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private OpenCVResult CaptureFace(Mat objMat)
        {
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            DetectFace.Detect(
              objMat, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
              faces, eyes,
              out detectionTime);

            // 重新計算比例
            decimal diWidth = decimal.Parse(picRender.Width.ToString()) / decimal.Parse(objMat.Bitmap.Width.ToString());
            decimal diHeight = decimal.Parse(picRender.Height.ToString()) / decimal.Parse(objMat.Bitmap.Height.ToString());

            List<Rectangle> objDraw = new List<Rectangle>();

            for (int i = 0; i < faces.Count; i++)
            {
                objDraw.Add(new Rectangle(
                    (int)(faces[i].X * diWidth),
                    (int)(faces[i].Y * diHeight),
                    (int)(faces[i].Width * diWidth),
                    (int)(faces[i].Height * diHeight)
                    ));
            }

            OpenCVResult result = new OpenCVResult()
            {
                eyes = eyes,
                faces = faces,
            };

            return result;
        }

        public class OpenCVResult
        {
            public List<Rectangle> faces { get; set; }
            public List<Rectangle> eyes { get; set; }
        }
    }
}
