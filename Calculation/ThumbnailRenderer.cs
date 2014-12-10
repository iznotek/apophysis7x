﻿using System;
using System.Drawing;
using Xyrus.Apophysis.Interfaces.Threading;
using Xyrus.Apophysis.Models;

namespace Xyrus.Apophysis.Calculation
{
	public class ThumbnailRenderer
	{
		public Bitmap CreateBitmap([NotNull] Flame flame, float density, Size size, IThreadStateToken threadState = null)
		{
			if (flame == null) throw new ArgumentNullException(@"flame");
			if (density <= 0) throw new ArgumentOutOfRangeException(@"density");
			if (size.Width <= 0 || size.Height <= 0) throw new ArgumentOutOfRangeException(@"size");

			var progress = new ProgressManager(threadState);

			using (var renderer = new Renderer(flame, size, 1, 0.5f, false))
			{
				renderer.Initialize();
				renderer.Histogram.Iterate(density, progress);

				return renderer.Histogram.CreateBitmap();
			}
		}
	}
}
