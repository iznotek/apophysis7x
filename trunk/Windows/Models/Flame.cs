﻿using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Xyrus.Apophysis.Models
{
	[PublicAPI]
	public class Flame
	{
		private IteratorCollection mIterators;
		private Palette mPalette;

		private static int mCounter;
		private int mIndex;
		private string mName;

		public Flame()
		{
			mIndex = ++mCounter;

			mIterators = new IteratorCollection(this);
			mPalette = PaletteCollection.GetRandomPalette(this);
		}

		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}
		public string CalculatedName
		{
			get
			{
				if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Name.Trim()))
				{
					var today = DateTime.Today;
					return ApophysisSettings.NamePrefix + @"-" +
						today.Year.ToString(CultureInfo.InvariantCulture).PadLeft(4, '0') +
						today.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
						today.Day.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + @"-" +
						mIndex.ToString(CultureInfo.InvariantCulture);
				}

				return Name;
			}
		}

		public IteratorCollection Iterators
		{
			get { return mIterators; }
		}

		[NotNull]
		public Palette Palette
		{
			get { return mPalette; }
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				mPalette = value;
			}
		}

		public Flame Copy()
		{
			var copy = new Flame();
			ReduceCounter();

			copy.mIndex = mIndex;
			copy.Name = mName;
			copy.mIterators = mIterators.Copy(copy);
			copy.mPalette = mPalette.Copy();

			return copy;
		}

		internal static void ReduceCounter()
		{
			mCounter--;
		}

		public void ReadXml([NotNull] XElement element)
		{
			if (element == null) throw new ArgumentNullException("element");

			if ("flame" != element.Name.ToString().ToLower())
			{
				throw new ApophysisException("Expected XML node \"flame\" but received \"" + element.Name + "\"");
			}

			var nameAttribute = element.Attribute(XName.Get("name"));
			Name = nameAttribute == null ? null : nameAttribute.Value;

			var iterators = element.Descendants(XName.Get("xform"));
			iterators = iterators.Concat(element.Descendants(XName.Get("finalxform")));
			Iterators.ReadXml(iterators);

			var palette = element.Descendants(XName.Get("palette")).FirstOrDefault();
			if (palette == null)
			{
				throw new ApophysisException("No descendant node \"palette\" found");
			}
			Palette.ReadCondensedHexData(palette.Value);
		}
		public bool IsEqual([NotNull] Flame flame)
		{
			if (flame == null) throw new ArgumentNullException("flame");

			if (!Equals(mName, flame.mName))
				return false;

			if (!mPalette.IsEqual(flame.mPalette))
				return false;

			if (!mIterators.IsEqual(flame.mIterators))
				return false;

			return true;
		}
	}
}