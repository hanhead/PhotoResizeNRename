using System;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PhotoResizeNRename
{

    public class ImageResizer
    {
        #region basic resize logic
        public Point ProportionablyResize(Point orginSize, Point targetSize)
        {
            Point Resized = orginSize;
            if (Resized.X > targetSize.X || Resized.Y > targetSize.Y)
            {
                if (Resized.X > Resized.Y)
                {
                    if (Resized.X > targetSize.X)
                    {
                        Resized = ResizeByX(targetSize, Resized);
                    }
                    else
                    {
                        Resized = ResizeByY(targetSize, Resized);
                    }
                }
                else
                {
                    if (Resized.Y > targetSize.Y)
                    {
                        Resized = ResizeByY(targetSize, Resized);
                    }
                    else
                    {
                        Resized = ResizeByX(targetSize, Resized);
                    }
                }
            }
            return Resized;
        }

        private Point ResizeByY(Point targetSize, Point Resized)
        {
            Resized.X = (int)((double)Resized.X * ((double)targetSize.Y / (double)Resized.Y));
            Resized.Y = targetSize.Y;
            if (Resized.X > targetSize.X)
            {
                Resized = ResizeByX(targetSize, Resized);
            }
            return Resized;
        }

        private Point ResizeByX(Point targetSize, Point Resized)
        {
            Resized.Y = (int)((double)Resized.Y * ((double)targetSize.X / (double)Resized.X));
            Resized.X = targetSize.X;
            if (Resized.Y > targetSize.Y)
            {
                Resized = ResizeByY(targetSize, Resized);
            }
            return Resized;
        }

        public Point ProportionablyResize(Point originSize, int targetWidth)
        {
            Point Resized = originSize;
            if (Resized.X > targetWidth)
            {
                Resized.Y = (int)(Resized.Y * ((double)targetWidth / Resized.X));
                Resized.X = targetWidth;
            }
            return Resized;
        }

        //original drawing procedure
        public Bitmap DrawResizedImage(int Width, int Height, Bitmap Source)
        {
            Bitmap _result = new Bitmap(Width, Height);
            if (_result.PropertyIdList.Contains(0x0112))
            {
                int rotationValue = _result.GetPropertyItem(0x0112).Value[0];
                switch (rotationValue)
                {
                    case 1:
                        break;
                    case 8:
                        _result.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case 3:
                        _result.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 6:
                        _result.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            for (int i = 0; i < Source.PropertyItems.Length; i++)
            {
                _result.SetPropertyItem(Source.PropertyItems[i]);
            }
            try
            {
                using (Graphics g = Graphics.FromImage(_result))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(Source, 0, 0, Width, Height);
                }
            }
            catch (Exception _exp)
            {
                _result.Dispose();
                throw _exp;
            }
            return _result;
        }

        public void SaveToFile(string resizedFilePath, ImageFormat ImgFormat, Bitmap Resized, bool RecommendJPEGOptions = false)
        {
            if (ImgFormat == ImageFormat.Jpeg && RecommendJPEGOptions)
            {
                using (EncoderParameters codecParams = new EncoderParameters(1))
                {
                    ImageCodecInfo _imageCodecInfo = ImageCodecInfo.GetImageEncoders().SingleOrDefault(ie => ie.MimeType == "image/jpeg");

                    Encoder qualityEncoder = Encoder.Quality;
                    codecParams.Param[0] = new EncoderParameter(qualityEncoder, 100L);
                    Resized.Save(resizedFilePath, _imageCodecInfo, codecParams);
                }
            }
            else
            {
                Resized.Save(resizedFilePath, ImgFormat);
            }
        }

        #endregion

        #region resize and return Bitmap

        #region from bitmap
        public Bitmap Resize(int Width, int Height, Bitmap Source, bool Proportionably = true)
        {
            Point TargetSize;
            if (Proportionably)
                TargetSize = ProportionablyResize((new Point(Source.Width, Source.Height)), (new Point(Width, Height)));
            else
                TargetSize = new Point(Width, Height);

            return DrawResizedImage(TargetSize.X, TargetSize.Y, Source);
        }
        public Bitmap Resize(int Width, Bitmap Source)
        {
            Point TargetSize = ProportionablyResize((new Point(Source.Width, Source.Height)), Width);
            return DrawResizedImage(TargetSize.X, TargetSize.Y, Source);
        }
        #endregion

        #region from file
        public Bitmap Resize(int Width, int Height, string FilePath, bool Proportionably = true)
        {
            Bitmap Resized;
            using (Bitmap Source = new Bitmap(FilePath))
            {
                Resized = Resize(Width, Height, Source, Proportionably);
            }
            return Resized;
        }
        public Bitmap Resize(int Width, string FilePath)
        {
            Bitmap Resized;
            using (Bitmap Source = new Bitmap(FilePath))
            {
                Resized = Resize(Width, Source);
            }
            return Resized;
        }
        #endregion

        #endregion

        #region resize and return stream

        #region from stream

        public Stream Resize2ImageStream(int Width, Stream imageStream)
        {
            Bitmap _bitmap = new Bitmap(imageStream);
            return Resize2ImageStream(Width, imageStream, _bitmap.RawFormat);
        }
        public Stream Resize2ImageStream(int Width, Stream imageStream, ImageFormat imageformat)
        {
            Bitmap _bitmap = new Bitmap(imageStream);
            Stream _stm = new MemoryStream();
            Resize(Width, _bitmap).Save(_stm, imageformat);
            return _stm;
        }
        public Stream Resize2ImageStream(int Width, int Height, Stream imageStream, bool Proportionably = true)
        {
            Bitmap _bitmap = new Bitmap(imageStream);
            return Resize2ImageStream(Width, Height, imageStream, _bitmap.RawFormat, Proportionably);
        }
        public Stream Resize2ImageStream(int Width, int Height, Stream imageStream, ImageFormat imageformat, bool Proportionably = true)
        {
            MemoryStream _stream = new MemoryStream();
            using (Bitmap _bitmap = new Bitmap(imageStream))
            {
                using (Bitmap _resizedbitmap = Resize(Width, Height, _bitmap, Proportionably))
                {
                    _resizedbitmap.Save(_stream, imageformat);
                }
            }
            return _stream;
        }
        #endregion

        #region from file
        public Stream Resize2ImageStream(int Width, string filepath)
        {
            Stream _stm = new MemoryStream();
            using (Bitmap _bitmap = Resize(Width, filepath))
            {
                Resize(Width, filepath).Save(_stm, _bitmap.RawFormat);
            }
            return _stm;
        }
        public Stream Resize2ImageStream(int Width, string filepath, ImageFormat imageformat)
        {
            Stream _stm = new MemoryStream();
            Resize(Width, filepath).Save(_stm, imageformat);
            return _stm;
        }
        public Stream Resize2ImageStream(int Width, int Height, string filepath, bool Proportionably = true)
        {
            Stream _stm = new MemoryStream();
            using (Bitmap _bitmap = Resize(Width, Height, filepath, Proportionably))
            {
                Resize(Width, Height, filepath, Proportionably).Save(_stm, _bitmap.RawFormat);
            }
            return _stm;
        }
        public Stream Resize2ImageStream(int Width, int Height, string filepath, ImageFormat imageformat, bool Proportionably = true)
        {
            Stream _stm = new MemoryStream();
            Resize(Width, Height, filepath, Proportionably).Save(_stm, imageformat);
            return _stm;
        }
        #endregion

        #endregion

        #region resize and save as file
        public void Resize2File(int Width, string FilePath, string resizedFilePath)
        {
            using (Bitmap Resized = Resize(Width, FilePath))
            {
                SaveToFile(resizedFilePath, Resized.RawFormat, Resized);
            }
        }

        public void Resize2FileByRecommendJPEG(int Width, string FilePath, string resizedFilePath)
        {
            using (Bitmap Resized = Resize(Width, FilePath))
            {
                SaveToFile(resizedFilePath, ImageFormat.Jpeg, Resized, true);
            }
        }

        public void Resize2File(int Width, string FilePath, string resizedFilePath, ImageFormat ImgFormat)
        {
            using (Bitmap Resized = Resize(Width, FilePath))
            {
                SaveToFile(resizedFilePath, ImgFormat, Resized);
            }
        }

        public void Resize2File(int Width, int Height, string FilePath, string resizedFilePath, bool Proportionably = true)
        {
            using (Bitmap Resized = Resize(Width, Height, FilePath, Proportionably))
            {
                SaveToFile(resizedFilePath, Resized.RawFormat, Resized);
            }
        }

        public void Resize2FileByRecommendJPEG(int Width, int Height, string FilePath, string resizedFilePath, bool Proportionably = true)
        {
            using (Bitmap Resized = Resize(Width, Height, FilePath, Proportionably))
            {
                SaveToFile(resizedFilePath, ImageFormat.Jpeg, Resized, true);
            }
        }

        public void Resize2File(int Width, int Height, string FilePath, string resizedFilePath, ImageFormat ImgFormat, bool Proportionably = true)
        {
            using (Bitmap Resized = Resize(Width, Height, FilePath, Proportionably))
            {
                SaveToFile(resizedFilePath, ImgFormat, Resized);
            }
        }
        #endregion
    }
}
