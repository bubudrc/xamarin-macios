//
// Unit tests for UITabBarController
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyright 2012 Xamarin Inc. All rights reserved.
//

#if !__WATCHOS__

using System;
using System.Drawing;
using System.Reflection;
#if XAMCORE_2_0
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

#if XAMCORE_2_0
using RectangleF=CoreGraphics.CGRect;
using SizeF=CoreGraphics.CGSize;
using PointF=CoreGraphics.CGPoint;
#else
using nfloat=global::System.Single;
using nint=global::System.Int32;
using nuint=global::System.UInt32;
#endif

namespace MonoTouchFixtures.UIKit {
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class TabBarControllerTest {
		
		void CheckDefault (UITabBarController c)
		{
#if !__TVOS__
			Assert.Null (c.CustomizableViewControllers, "CustomizableViewControllers");
			Assert.NotNull (c.MoreNavigationController, "MoreNavigationController");
#endif
			Assert.That (c.SelectedIndex, Is.EqualTo (nint.MaxValue), "SelectedIndex");
			Assert.Null (c.SelectedViewController, "SelectedViewController");
			Assert.Null (c.ShouldSelectViewController, "ShouldSelectViewController");
			Assert.NotNull (c.TabBar, "TabBar");
			Assert.Null (c.ViewControllers, "ViewControllers");
		}
		
		[Test]
		public void Ctor_Defaults ()
		{
			using (UITabBarController c = new UITabBarController ()) {
				CheckDefault (c);
			}
		}

		[Test]
		public void Ctor_Nib ()
		{
			using (UITabBarController c = new UITabBarController ("EmptyNib", null)) {
				// `initWithNibName:bundle:` is defined on a base class so it does not
				// affect the fields from UITabBarController
				CheckDefault (c);
			}
		}
	}
}

#endif // !__WATCHOS__