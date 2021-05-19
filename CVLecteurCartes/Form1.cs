using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVLecteurCartes
{
    public partial class Form1 : Form
    {
        public Point[] pts =
        {
            new Point(414,575),
            new Point(413,576),
            new Point(410,576),
            new Point(409,577),
            new Point(407,577),
            new Point(405,579),
            new Point(404,579),
            new Point(398,585),
            new Point(398,587),
            new Point(396,589),
            new Point(396,593),
            new Point(395,594),
            new Point(395,602),
            new Point(394,603),
            new Point(394,610),
            new Point(393,611),
            new Point(394,612),
            new Point(394,614),
            new Point(393,615),
            new Point(393,617),
            new Point(394,618),
            new Point(392,620),
            new Point(393,621),
            new Point(393,625),
            new Point(392,626),
            new Point(391,626),
            new Point(392,627),
            new Point(392,636),
            new Point(391,637),
            new Point(391,639),
            new Point(392,640),
            new Point(392,641),
            new Point(391,642),
            new Point(391,643),
            new Point(390,644),
            new Point(391,645),
            new Point(391,650),
            new Point(390,651),
            new Point(390,654),
            new Point(391,655),
            new Point(390,656),
            new Point(390,661),
            new Point(389,662),
            new Point(389,670),
            new Point(388,671),
            new Point(388,678),
            new Point(387,679),
            new Point(388,680),
            new Point(388,682),
            new Point(387,683),
            new Point(387,693),
            new Point(386,694),
            new Point(386,702),
            new Point(385,703),
            new Point(385,708),
            new Point(386,709),
            new Point(385,710),
            new Point(385,715),
            new Point(383,717),
            new Point(384,717),
            new Point(385,718),
            new Point(384,719),
            new Point(384,726),
            new Point(383,727),
            new Point(384,728),
            new Point(383,729),
            new Point(383,731),
            new Point(382,732),
            new Point(383,733),
            new Point(383,737),
            new Point(382,738),
            new Point(382,742),
            new Point(381,743),
            new Point(382,744),
            new Point(381,745),
            new Point(382,746),
            new Point(382,749),
            new Point(381,750),
            new Point(381,751),
            new Point(380,752),
            new Point(380,755),
            new Point(381,756),
            new Point(381,757),
            new Point(380,758),
            new Point(380,766),
            new Point(379,767),
            new Point(379,780),
            new Point(378,781),
            new Point(378,789),
            new Point(377,790),
            new Point(377,798),
            new Point(376,799),
            new Point(377,800),
            new Point(376,801),
            new Point(376,804),
            new Point(377,805),
            new Point(377,806),
            new Point(376,807),
            new Point(376,808),
            new Point(375,809),
            new Point(375,826),
            new Point(376,827),
            new Point(376,829),
            new Point(378,831),
            new Point(378,832),
            new Point(381,835),
            new Point(381,836),
            new Point(382,837),
            new Point(383,837),
            new Point(384,838),
            new Point(385,838),
            new Point(386,839),
            new Point(389,839),
            new Point(390,840),
            new Point(394,840),
            new Point(395,841),
            new Point(402,841),
            new Point(403,842),
            new Point(413,842),
            new Point(414,843),
            new Point(420,843),
            new Point(421,844),
            new Point(422,843),
            new Point(426,843),
            new Point(427,844),
            new Point(433,844),
            new Point(434,845),
            new Point(435,844),
            new Point(436,844),
            new Point(437,845),
            new Point(444,845),
            new Point(445,846),
            new Point(446,845),
            new Point(447,846),
            new Point(453,846),
            new Point(454,847),
            new Point(455,846),
            new Point(456,846),
            new Point(457,847),
            new Point(458,846),
            new Point(459,846),
            new Point(460,847),
            new Point(467,847),
            new Point(468,848),
            new Point(475,848),
            new Point(476,849),
            new Point(477,848),
            new Point(478,849),
            new Point(482,849),
            new Point(483,850),
            new Point(485,850),
            new Point(486,849),
            new Point(488,849),
            new Point(489,850),
            new Point(490,849),
            new Point(491,850),
            new Point(497,850),
            new Point(498,851),
            new Point(499,850),
            new Point(500,851),
            new Point(504,851),
            new Point(505,852),
            new Point(506,851),
            new Point(509,851),
            new Point(510,852),
            new Point(512,852),
            new Point(513,851),
            new Point(514,852),
            new Point(523,852),
            new Point(524,853),
            new Point(530,853),
            new Point(531,852),
            new Point(535,852),
            new Point(536,851),
            new Point(539,851),
            new Point(543,847),
            new Point(544,847),
            new Point(544,845),
            new Point(546,843),
            new Point(546,842),
            new Point(547,841),
            new Point(547,840),
            new Point(548,839),
            new Point(548,835),
            new Point(549,834),
            new Point(549,825),
            new Point(550,824),
            new Point(550,823),
            new Point(549,822),
            new Point(549,820),
            new Point(550,819),
            new Point(550,812),
            new Point(551,811),
            new Point(550,810),
            new Point(550,808),
            new Point(551,807),
            new Point(551,800),
            new Point(552,799),
            new Point(551,798),
            new Point(551,797),
            new Point(552,796),
            new Point(552,789),
            new Point(553,788),
            new Point(553,787),
            new Point(552,786),
            new Point(552,784),
            new Point(553,783),
            new Point(553,780),
            new Point(554,779),
            new Point(553,778),
            new Point(553,773),
            new Point(554,772),
            new Point(554,767),
            new Point(555,766),
            new Point(555,763),
            new Point(554,762),
            new Point(555,761),
            new Point(555,760),
            new Point(556,759),
            new Point(555,758),
            new Point(555,753),
            new Point(556,752),
            new Point(556,750),
            new Point(555,749),
            new Point(555,748),
            new Point(557,746),
            new Point(557,745),
            new Point(556,744),
            new Point(556,741),
            new Point(557,740),
            new Point(557,731),
            new Point(558,730),
            new Point(558,726),
            new Point(559,725),
            new Point(559,724),
            new Point(558,723),
            new Point(558,720),
            new Point(559,719),
            new Point(559,709),
            new Point(560,708),
            new Point(560,704),
            new Point(561,703),
            new Point(562,704),
            new Point(563,704),
            new Point(563,703),
            new Point(561,703),
            new Point(560,702),
            new Point(560,701),
            new Point(561,700),
            new Point(560,699),
            new Point(560,695),
            new Point(561,694),
            new Point(561,691),
            new Point(562,690),
            new Point(562,688),
            new Point(561,687),
            new Point(562,686),
            new Point(562,683),
            new Point(563,682),
            new Point(562,681),
            new Point(562,680),
            new Point(561,679),
            new Point(561,678),
            new Point(562,677),
            new Point(563,677),
            new Point(564,678),
            new Point(565,678),
            new Point(565,677),
            new Point(564,677),
            new Point(563,676),
            new Point(563,675),
            new Point(562,674),
            new Point(563,673),
            new Point(563,672),
            new Point(564,671),
            new Point(563,670),
            new Point(563,669),
            new Point(564,668),
            new Point(563,667),
            new Point(563,666),
            new Point(564,665),
            new Point(564,656),
            new Point(565,655),
            new Point(565,654),
            new Point(566,653),
            new Point(566,652),
            new Point(565,651),
            new Point(565,646),
            new Point(566,645),
            new Point(566,640),
            new Point(567,639),
            new Point(566,638),
            new Point(566,632),
            new Point(567,631),
            new Point(567,627),
            new Point(568,626),
            new Point(568,613),
            new Point(569,612),
            new Point(569,603),
            new Point(568,602),
            new Point(568,600),
            new Point(567,599),
            new Point(567,598),
            new Point(566,597),
            new Point(566,596),
            new Point(563,593),
            new Point(562,593),
            new Point(561,592),
            new Point(561,591),
            new Point(560,591),
            new Point(559,590),
            new Point(558,590),
            new Point(557,589),
            new Point(550,589),
            new Point(549,588),
            new Point(549,587),
            new Point(548,587),
            new Point(547,588),
            new Point(542,588),
            new Point(541,587),
            new Point(537,587),
            new Point(536,586),
            new Point(535,586),
            new Point(534,587),
            new Point(532,587),
            new Point(531,586),
            new Point(528,586),
            new Point(527,587),
            new Point(526,586),
            new Point(524,586),
            new Point(523,585),
            new Point(522,586),
            new Point(521,585),
            new Point(517,585),
            new Point(516,586),
            new Point(515,585),
            new Point(511,585),
            new Point(510,584),
            new Point(501,584),
            new Point(500,583),
            new Point(498,583),
            new Point(497,584),
            new Point(496,584),
            new Point(495,583),
            new Point(489,583),
            new Point(488,582),
            new Point(484,582),
            new Point(483,581),
            new Point(469,581),
            new Point(468,580),
            new Point(458,580),
            new Point(457,579),
            new Point(452,579),
            new Point(451,578),
            new Point(450,578),
            new Point(449,579),
            new Point(447,579),
            new Point(446,578),
            new Point(439,578),
            new Point(438,577),
            new Point(437,578),
            new Point(436,578),
            new Point(435,577),
            new Point(424,577),
            new Point(423,576),
            new Point(415,576)
        };

        static private PointF moindreCarré(Point[] pts)
        {
            double[,] mat = new double[2, 2];
            mat[0, 0] = pts.Sum(p => p.X * p.X);
            mat[0, 1] = pts.Sum(p => p.X);
            mat[1, 0] = mat[0, 1];
            mat[1, 1] = pts.Length;
            Matrix<double> A = DenseMatrix.OfArray(mat).Inverse();

            double[] vec = new double[2];
            vec[0] = pts.Sum(p => p.X * p.Y);
            vec[1] = pts.Sum(p => p.Y);
            Vector<double> V = DenseVector.OfArray(vec);

            Vector<double> R = A * V;
            return new PointF((float)R[0], (float)R[1]);
        }

        //static private double unSurRacineDeDeux = 0.70710678118654752440084436210485;

        static private (PointF, PointF) moindreCarréV(Point[] pts)
        {
            long sumX = pts.Sum(p => p.X);
            long sumY = pts.Sum(p => p.Y);

            double[,] mat = new double[2, 2];
            mat[0, 0] = pts.Sum(p => p.X * p.X);
            mat[0, 1] = sumX;
            mat[1, 0] = sumX;
            mat[1, 1] = pts.Length;
            Matrix<double> A = DenseMatrix.OfArray(mat).Inverse();

            double[] vec = new double[2];
            vec[0] = pts.Sum(p => p.X * p.Y);
            vec[1] = sumY;
            Vector<double> V = DenseVector.OfArray(vec);

            Vector<double> Ry = A * V;

            mat[0, 0] = pts.Sum(p => p.Y * p.Y);
            mat[0, 1] = sumY;
            mat[1, 0] = sumY;

            A = DenseMatrix.OfArray(mat).Inverse();
            vec[1] = sumX;
            V = DenseVector.OfArray(vec);

            Vector<double> Rx = A * V;

            if(double.IsNaN(Rx[0]) && double.IsNaN(Ry[0]))
            {
                return (PointF.Empty, PointF.Empty);
            }

            PointF pline, vline;

            PointF mp = new PointF(sumX, sumY);
            mp.X /= pts.Length;
            mp.Y /= pts.Length;

            double RxDelta = Math.Abs(Rx[0]);
            double RyDelta = Math.Abs(Ry[0]);

            if (double.IsNaN(Rx[0]) || (double.IsNaN(Ry[0]) == false && RyDelta < RxDelta))
            {
                double hypo = Math.Sqrt(Ry[0] * Ry[0] + 1.0);
                vline = new PointF((float)(1.0 / hypo), (float)(Ry[0] / hypo));
                pline = new PointF(0.0f, (float)(Ry[1]));

                PointF plmp = new PointF(mp.X - pline.X, mp.Y - pline.Y);
                float dot = -vline.Y * plmp.X + vline.X * plmp.Y;
                pline.X = mp.X - dot * vline.Y;
                pline.Y = mp.Y + dot * vline.X;
            }
            else
            {
                double hypo = Math.Sqrt(Rx[0] * Rx[0] + 1.0);
                vline = new PointF((float)(Rx[0] / hypo), (float)(1.0 / hypo));
                pline = new PointF((float)(Rx[1]), 0.0f);

                PointF plmp = new PointF(mp.X - pline.X, mp.Y - pline.Y);
                float dot = -vline.Y * plmp.X + vline.X * plmp.Y;
                pline.X = mp.X - dot * vline.Y;
                pline.Y = mp.Y + dot * vline.X;
            }

            return (pline, vline);
        }

        static private (PointF, PointF) moindreCarréVP(Point[] pts)
        {
            long sumX = pts.Sum(p => p.X);
            long sumY = pts.Sum(p => p.Y);

            double[,] mat = new double[2, 2];
            mat[0, 0] = pts.Sum(p => p.X * p.X);
            mat[0, 1] = sumX;
            mat[1, 0] = sumX;
            mat[1, 1] = pts.Length;
            Matrix<double> A = DenseMatrix.OfArray(mat).Inverse();

            double[] vec = new double[2];
            vec[0] = pts.Sum(p => p.X * p.Y);
            vec[1] = sumY;
            Vector<double> V = DenseVector.OfArray(vec);

            Vector<double> Ry = A * V;

            mat[0, 0] = pts.Sum(p => p.Y * p.Y);
            mat[0, 1] = sumY;
            mat[1, 0] = sumY;

            A = DenseMatrix.OfArray(mat).Inverse();
            vec[1] = sumX;
            V = DenseVector.OfArray(vec);

            Vector<double> Rx = A * V;

            if (double.IsNaN(Rx[0]) && double.IsNaN(Ry[0]))
            {
                return (PointF.Empty, PointF.Empty);
            }

            PointF pline, vline;

            PointF mp = new PointF(sumX, sumY);
            mp.X /= pts.Length;
            mp.Y /= pts.Length;

            double RxDelta = Math.Abs(Rx[0]);
            double RyDelta = Math.Abs(Ry[0]);

            if (double.IsNaN(Rx[0]) || RxDelta > 100.0f)
            {
                double hypo = Math.Sqrt(Ry[0] * Ry[0] + 1.0);
                vline = new PointF((float)(1.0 / hypo), (float)(Ry[0] / hypo));
                pline = new PointF(0.0f, (float)(Ry[1]));

                PointF plmp = new PointF(mp.X - pline.X, mp.Y - pline.Y);
                float dot = -vline.Y * plmp.X + vline.X * plmp.Y;
                pline.X = mp.X - dot * vline.Y;
                pline.Y = mp.Y + dot * vline.X;
            }
            else if (double.IsNaN(Ry[0]) || RyDelta > 100.0f)
            {
                double hypo = Math.Sqrt(Rx[0] * Rx[0] + 1.0);
                vline = new PointF((float)(Rx[0] / hypo), (float)(1.0 / hypo));
                pline = new PointF((float)(Rx[1]), 0.0f);

                PointF plmp = new PointF(mp.X - pline.X, mp.Y - pline.Y);
                float dot = -vline.Y * plmp.X + vline.X * plmp.Y;
                pline.X = mp.X - dot * vline.Y;
                pline.Y = mp.Y + dot * vline.X;
            }
            else
            {
                double hypo;
                PointF plmp;
                float dot;

                PointF vlY;
                PointF plY;
                PointF vlX;
                PointF plX;


                hypo = Math.Sqrt(Ry[0] * Ry[0] + 1.0);
                vlY = new PointF((float)(1.0 / hypo), (float)(Ry[0] / hypo));
                plY = new PointF(0.0f, (float)(Ry[1]));

                plmp = new PointF(mp.X - plY.X, mp.Y - plY.Y);
                dot = -vlY.Y * plmp.X + vlY.X * plmp.Y;
                plY.X = mp.X - dot * vlY.Y;
                plY.Y = mp.Y + dot * vlY.X;


                hypo = Math.Sqrt(Rx[0] * Rx[0] + 1.0);
                vlX = new PointF((float)(Rx[0] / hypo), (float)(1.0 / hypo));
                plX = new PointF((float)(Rx[1]), 0.0f);

                plmp = new PointF(mp.X - plX.X, mp.Y - plX.Y);
                dot = -vlX.Y * plmp.X + vlX.X * plmp.Y;
                plX.X = mp.X - dot * vlX.Y;
                plX.Y = mp.Y + dot * vlX.X;


                double maxDelta = RxDelta + RyDelta;
                double wx = RyDelta / maxDelta;
                double wy = RxDelta / maxDelta;

                if (VPoint.dot(vlY, vlX) < 0.0f)
                {
                    vlY.X = -vlY.X;
                    vlY.Y = -vlY.Y;
                }

                pline = new PointF((float)(plY.X * wy + plX.X * wx), (float)(plY.Y * wy + plX.Y * wx));
                vline = new PointF((float)(vlY.X * wy + vlX.X * wx), (float)(vlY.Y * wy + vlX.Y * wx));
                hypo = Math.Sqrt(vline.X * vline.X + vline.Y * vline.Y);
                vline.X = (float)(vline.X / hypo);
                vline.Y = (float)(vline.Y / hypo);
            }

            return (pline, vline);
        }

        private class VPoint
        {
            public PointF p;
            public PointF n;

            public VPoint(PointF _p, PointF _n)
            {
                p = _p;
                n = _n;
            }

            public static float LineDist((PointF, PointF, Color, int) ln, PointF pt)
            {
                return (-ln.Item2.Y * (pt.X - ln.Item1.X) + ln.Item2.X * (pt.Y - ln.Item1.Y));
            }

            public static float LineDist((PointF, PointF, Color, int) ln, Point pt)
            {
                return (-ln.Item2.Y * (pt.X - ln.Item1.X) + ln.Item2.X * (pt.Y - ln.Item1.Y));
            }

            public static float LineDist((PointF,PointF) ln, Point pt)
            {
                return (-ln.Item2.Y * (pt.X-ln.Item1.X) + ln.Item2.X * (pt.Y-ln.Item1.Y));
            }

            static public float dot(PointF va, PointF vb)
            {
                return va.X * vb.X + va.Y * vb.Y;
            }

            static public float hypo(PointF v)
            {
                return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            }

            static public PointF normalise(PointF v)
            {
                float h = hypo(v);
                return new PointF(v.X / h, v.Y / h);
            }
        }

        private Point[] drawPtsUa;
        private Point[] drawPtsUb;
        private Point[] drawPtsVa;
        private Point[] drawPtsVb;
        private List<VPoint> vpts;
        //private PointF resLine;
        private (PointF, PointF, Color, int)[] resLineV = new (PointF, PointF, Color, int)[10];

        static private (PointF, PointF, Color, int)  TLineToTlineColor((PointF, PointF) tl, Color c, int ln)
        {
            return (tl.Item1, tl.Item2, c, ln);
        }

        static public readonly (PointF, PointF, Color, int) EmptyTLineColor = (PointF.Empty, Point.Empty, Color.Empty, 0);
        static public readonly (PointF, PointF) EmptyTLine = (PointF.Empty, Point.Empty);

        public Form1()
        {
            InitializeComponent();

            int msz = 10;
            resLineV[0] = TLineToTlineColor(moindreCarréV(pts), Color.DarkMagenta, 20);
            vpts = pts.Select(p => new VPoint(p, PointF.Empty)).ToList();
            for (int i = 0; i < vpts.Count; ++i)
            {
                VPoint a = vpts[(i + vpts.Count - msz) % vpts.Count];
                VPoint p = vpts[i];
                VPoint b = vpts[(i + msz) % vpts.Count];
                PointF ab = new PointF(b.p.X - a.p.X, b.p.Y - a.p.Y);
                float hyp = (float)Math.Sqrt(ab.X * ab.X + ab.Y * ab.Y);
                p.n = new PointF(ab.X / hyp, ab.Y / hyp);
            }

            resLineV[1] = (resLineV[0].Item1, new PointF(-resLineV[0].Item2.Y, resLineV[0].Item2.X), Color.DarkMagenta, 20);

            List<VPoint> vptsU = new List<VPoint>();
            List<VPoint> vptsV = new List<VPoint>();
            foreach (VPoint vp in vpts)
            {
                float dotU = Math.Abs(resLineV[0].Item2.X * vp.n.X + resLineV[0].Item2.Y * vp.n.Y);
                float dotV = Math.Abs(resLineV[1].Item2.X * vp.n.X + resLineV[1].Item2.Y * vp.n.Y);
                if (dotU > dotV) vptsU.Add(vp);
                else vptsV.Add(vp);
            }

            Point[] ptsU = vptsU.Select(p => new Point((int)p.p.X, (int)p.p.Y)).ToArray();
            Point[] ptsUa = ptsU.Where(p => VPoint.LineDist(resLineV[0], p) < 0.0).ToArray();
            Point[] ptsUb = ptsU.Where(p => VPoint.LineDist(resLineV[0], p) >= 0.0).ToArray();

            resLineV[2] = TLineToTlineColor(moindreCarréVP(ptsUa), Color.Blue, 150);
            resLineV[3] = TLineToTlineColor(moindreCarréVP(ptsUb), Color.Blue, 150);

            Point[] ptsV = vptsV.Select(p => new Point((int)p.p.X, (int)p.p.Y)).ToArray();
            Point[] ptsVa = ptsV.Where(p => VPoint.LineDist(resLineV[1], p) < 0.0).ToArray();
            Point[] ptsVb = ptsV.Where(p => VPoint.LineDist(resLineV[1], p) >= 0.0).ToArray();

            resLineV[4] = TLineToTlineColor(moindreCarréVP(ptsVa), Color.Blue, 110);
            resLineV[5] = TLineToTlineColor(moindreCarréVP(ptsVb), Color.Blue, 110);

            mixLine();

            //drawPts = ptsVb;
            //resLineV[0] = EmptyTLineColor;

            drawPtsUa = ptsUa.ToArray();
            drawPtsUb = ptsUb.ToArray();
            drawPtsVa = ptsVa.ToArray();
            drawPtsVb = ptsVb.ToArray();

            this.Refresh();
        }

        private void mixLine()
        {
            PointF v;

            if(VPoint.dot(resLineV[2].Item2, resLineV[3].Item2)>=0)
            {
                v = new PointF(resLineV[2].Item2.X + resLineV[3].Item2.X, resLineV[2].Item2.Y + resLineV[3].Item2.Y);
            }
            else
            {
                v = new PointF(resLineV[2].Item2.X - resLineV[3].Item2.X, resLineV[2].Item2.Y - resLineV[3].Item2.Y);
            }
            resLineV[2].Item2 = resLineV[3].Item2 = VPoint.normalise(v);

            if (VPoint.dot(resLineV[4].Item2, resLineV[5].Item2) >= 0)
            {
                v = new PointF(resLineV[4].Item2.X + resLineV[5].Item2.X, resLineV[4].Item2.Y + resLineV[5].Item2.Y);
            }
            else
            {
                v = new PointF(resLineV[4].Item2.X - resLineV[5].Item2.X, resLineV[4].Item2.Y - resLineV[5].Item2.Y);
            }
            resLineV[4].Item2 = resLineV[5].Item2 = VPoint.normalise(v);
        }

        private void draw(Graphics g)
        {
            int sz = 2;
            Point bp = new Point(-250, -450);

            Brush brsh = new SolidBrush(Color.Pink);
            foreach (VPoint p in vpts)
                g.FillEllipse(brsh, bp.X + p.p.X + sz/2, bp.Y + p.p.Y + sz / 2, sz, sz);

            if (drawPtsUa != null)
            {
                brsh = new SolidBrush(Color.DarkRed);
                foreach (Point p in drawPtsUa)
                    g.FillEllipse(brsh, bp.X + p.X + sz / 2, bp.Y + p.Y + sz / 2, sz, sz);
            }
            if (drawPtsUb != null)
            {
                brsh = new SolidBrush(Color.DarkGreen);
                foreach (Point p in drawPtsUb)
                    g.FillEllipse(brsh, bp.X + p.X + sz / 2, bp.Y + p.Y + sz / 2, sz, sz);
            }
            if (drawPtsVa != null)
            {
                brsh = new SolidBrush(Color.DarkGoldenrod);
                foreach (Point p in drawPtsVa)
                    g.FillEllipse(brsh, bp.X + p.X + sz / 2, bp.Y + p.Y + sz / 2, sz, sz);
            }
            if (drawPtsVb != null)
            {
                brsh = new SolidBrush(Color.DarkOrange);
                foreach (Point p in drawPtsVb)
                    g.FillEllipse(brsh, bp.X + p.X + sz / 2, bp.Y + p.Y + sz / 2, sz, sz);
            }

            /*Point pLine = new Point((int)(bp.X + 0.0f), (int)(bp.Y + resLine.Y));
            int lineNLen = 320;
            Point pStart = new Point(pLine.X + (int)(1.0f * lineNLen), pLine.Y + (int)(resLine.X * lineNLen));
            int lineLen = 2000;
            Point pEnd = new Point(pStart.X + (int)(1.0f * lineLen), pStart.Y + (int)(resLine.X * lineLen));
            Pen pn = new Pen(Color.Blue);
            g.DrawLine(pn, pStart, pEnd);*/

            foreach (var ln in resLineV)
            {
                int lineLen = ln.Item4;
                Point pStart = new Point(bp.X + (int)(ln.Item1.X - ln.Item2.X * lineLen), bp.Y + (int)(ln.Item1.Y - ln.Item2.Y * lineLen));
                Point pEnd = new Point(bp.X + (int)(ln.Item1.X + ln.Item2.X * lineLen), bp.Y + (int)(ln.Item1.Y + ln.Item2.Y * lineLen));
                Pen pn = new Pen(ln.Item3);
                g.DrawLine(pn, pStart, pEnd);

                int nlen = 15;
                pStart = new Point(bp.X + (int)(ln.Item1.X), bp.Y + (int)(ln.Item1.Y));
                pEnd = new Point(bp.X + (int)(ln.Item1.X - ln.Item2.Y * nlen), bp.Y + (int)(ln.Item1.Y + ln.Item2.X * nlen));
                g.DrawLine(pn, pStart, pEnd);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            draw(e.Graphics);
        }

        private float[] L_minD = new float[4] { float.MinValue, float.MinValue, float.MinValue, float.MinValue };
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Point> ptsUa = new List<Point>();
            List<Point> ptsUb = new List<Point>();
            List<Point> ptsVa = new List<Point>();
            List<Point> ptsVb = new List<Point>();

            float[] l_minD = new float[4] { float.MinValue, float.MinValue, float.MinValue, float.MinValue };
            float[] l_dot = new float[4];
            List<Point>[] l_pts = new List<Point>[4] { ptsUa, ptsUb, ptsVa, ptsVb };

            Random rnd = new Random();
            foreach(Point p in pts)
            {
                l_dot[0] = Math.Abs(VPoint.LineDist(resLineV[2], p));// dotUa
                l_dot[1] = Math.Abs(VPoint.LineDist(resLineV[3], p));// dotUb
                l_dot[2] = Math.Abs(VPoint.LineDist(resLineV[4], p));// dotVa
                l_dot[3] = Math.Abs(VPoint.LineDist(resLineV[5], p));// dotVb

                int minIdx = rnd.Next(4);
                float minD = l_dot[minIdx];
                for(int i = 0; i < 4; ++i)
                {
                    if(l_dot[i] < minD)
                    {
                        minD = l_dot[i];
                        minIdx = i;
                    }
                }

                l_pts[minIdx].Add(p);
                if(l_minD[minIdx] < minD)
                {
                    l_minD[minIdx] = minD;
                }
            }

            resLineV[2] = TLineToTlineColor(moindreCarréVP(ptsUa.ToArray()), Color.Blue, 150);
            resLineV[3] = TLineToTlineColor(moindreCarréVP(ptsUb.ToArray()), Color.Blue, 150);

            resLineV[4] = TLineToTlineColor(moindreCarréVP(ptsVa.ToArray()), Color.Blue, 110);
            resLineV[5] = TLineToTlineColor(moindreCarréVP(ptsVb.ToArray()), Color.Blue, 110);

            mixLine();

            drawPtsUa = ptsUa.ToArray();
            drawPtsUb = ptsUb.ToArray();
            drawPtsVa = ptsVa.ToArray();
            drawPtsVb = ptsVb.ToArray();

            //if(L_minD.Zip(l_minD, (x,y) => (Math.Abs(y-x) > 0.0f)).Contains(true) == false)
            if (L_minD.Max(x => (x<0 ? float.MaxValue : x)) <= l_minD.Max())
            {
                timer1.Enabled = false;
                MessageBox.Show("Finish");
                if(VPoint.LineDist(resLineV[2], resLineV[0].Item1) <= 0.0f)
                {
                    resLineV[2].Item2.X = -resLineV[2].Item2.X;
                    resLineV[2].Item2.Y = -resLineV[2].Item2.Y;
                }
                if (VPoint.LineDist(resLineV[3], resLineV[0].Item1) <= 0.0f)
                {
                    resLineV[3].Item2.X = -resLineV[3].Item2.X;
                    resLineV[3].Item2.Y = -resLineV[3].Item2.Y;
                }
                if (VPoint.LineDist(resLineV[4], resLineV[0].Item1) <= 0.0f)
                {
                    resLineV[4].Item2.X = -resLineV[4].Item2.X;
                    resLineV[4].Item2.Y = -resLineV[4].Item2.Y;
                }
                if (VPoint.LineDist(resLineV[5], resLineV[0].Item1) <= 0.0f)
                {
                    resLineV[5].Item2.X = -resLineV[5].Item2.X;
                    resLineV[5].Item2.Y = -resLineV[5].Item2.Y;
                }

                float md;
                md = drawPtsUa.Min(p => VPoint.LineDist(resLineV[2], p));
                {
                    resLineV[2].Item1.X += -resLineV[2].Item2.Y * md;
                    resLineV[2].Item1.Y += resLineV[2].Item2.X * md;
                }

                md = drawPtsUb.Min(p => VPoint.LineDist(resLineV[3], p));
                {
                    resLineV[3].Item1.X += -resLineV[3].Item2.Y * md;
                    resLineV[3].Item1.Y += resLineV[3].Item2.X * md;
                }

                md = drawPtsVa.Min(p => VPoint.LineDist(resLineV[4], p));
                {
                    resLineV[4].Item1.X += -resLineV[4].Item2.Y * md;
                    resLineV[4].Item1.Y += resLineV[4].Item2.X * md;
                }

                md = drawPtsVb.Min(p => VPoint.LineDist(resLineV[5], p));
                {
                    resLineV[5].Item1.X += -resLineV[5].Item2.Y * md;
                    resLineV[5].Item1.Y += resLineV[5].Item2.X * md;
                }
            }

            L_minD = l_minD;
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
