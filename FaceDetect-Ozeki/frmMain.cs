using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetect_Ozeki
{
    public partial class frmMain : Form
    {
        private OzekiCamera _camera;
        private MediaConnector _connector;
        private CameraURLBuilderWF _myCameraUrlBuilder;
        private ImageProcesserHandler _imageProcesserHandler;
        private IFaceDetector _faceDetector;
        private FrameCapture _frameCapture;
        private DrawingImageProvider _originalImageProvider;
        private DrawingImageProvider _processedImageProvider;

        public frmMain()
        {
            InitializeComponent();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            Init();

            SetVideoViewers();

            InitDetectorFields();
        }

        void Init()
        {
            _frameCapture = new FrameCapture();
            _frameCapture.SetInterval(5);
            _myCameraUrlBuilder = new CameraURLBuilderWF();
            _connector = new MediaConnector();
            _originalImageProvider = new DrawingImageProvider();
            _processedImageProvider = new DrawingImageProvider();

            _faceDetector = ImageProcesserFactory.CreateFaceDetector();

            _imageProcesserHandler = new ImageProcesserHandler();
            _imageProcesserHandler.AddProcesser(_faceDetector);
        }

        void SetVideoViewers()
        {
            OriginalViewer.SetImageProvider(_originalImageProvider);
            ProcessedViewer.SetImageProvider(_processedImageProvider);
        }

        void InitDetectorFields()
        {
            InvokeGuiThread(() =>
            {
                tbMinSizeWidth.Text = _faceDetector.MinSize.Width.ToString();
                tbMaxSizeWidth.Text = _faceDetector.MaxSize.Width.ToString();
                tbMinSizeHeight.Text = _faceDetector.MinSize.Height.ToString();
                tbMaxSizeHeight.Text = _faceDetector.MaxSize.Height.ToString();
            });
        }

        void ConnectCam()
        {
            _connector.Connect(_camera.VideoChannel, _originalImageProvider);
            _connector.Connect(_camera.VideoChannel, _frameCapture);
            _connector.Connect(_frameCapture, _imageProcesserHandler);
            _connector.Connect(_imageProcesserHandler, _processedImageProvider);
        }

        void Start()
        {
            OriginalViewer.Start();
            ProcessedViewer.Start();

            _frameCapture.Start();
            _camera.Start();
            _imageProcesserHandler.Start();
        }

        void InvokeGuiThread(Action action)
        {
            BeginInvoke(action);
        }

        private void button_Compose_Click(object sender, EventArgs e)
        {
            var result = _myCameraUrlBuilder.ShowDialog();

            if (result != DialogResult.OK) return;

            tb_cameraUrl.Text = _myCameraUrlBuilder.CameraURL;

            button_Connect.Enabled = true;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (_camera != null)
            {
                _camera.CameraStateChanged -= _camera_CameraStateChanged;
                _camera.Disconnect();
                _connector.Disconnect(_camera.VideoChannel, _processedImageProvider);
                _connector.Disconnect(_camera.VideoChannel, _originalImageProvider);
                _camera.Dispose();
                _camera = null;
            }

            _camera = new OzekiCamera(_myCameraUrlBuilder.CameraURL);
            _camera.CameraStateChanged += _camera_CameraStateChanged;
            button_Connect.Enabled = false;
            ConnectCam();
            Start();
        }

        private void _camera_CameraStateChanged(object sender, CameraStateEventArgs e)
        {
            InvokeGuiThread(() =>
            {
                if (e.State == CameraState.Streaming)
                    button_Disconnect.Enabled = true;

                if (e.State == CameraState.Disconnected)
                {
                    button_Connect.Enabled = true;
                    button_Disconnect.Enabled = false;
                }
            });

            InvokeGuiThread(() =>
            {
                stateLabel.Text = e.State.ToString();
            });
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            if (_camera == null) return;

            _camera.Disconnect();
            _connector.Disconnect(_camera.VideoChannel, _originalImageProvider);
            _connector.Disconnect(_camera.VideoChannel, _processedImageProvider);

            _camera = null;
        }

        private void buttonSetFace_Click(object sender, EventArgs e)
        {
            InvokeGuiThread(() =>
            {
                _faceDetector.MinSize = new Size(Int32.Parse(tbMinSizeWidth.Text), Int32.Parse(tbMinSizeHeight.Text));
                _faceDetector.MaxSize = new Size(Int32.Parse(tbMaxSizeWidth.Text), Int32.Parse(tbMaxSizeHeight.Text));
            });
        }
    }
}
