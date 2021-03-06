using System;
using NUnit.Framework;
#if XAMCORE_2_0
using Foundation;
using CloudKit;
#else
using MonoTouch.Foundation;
using MonoTouch.CloudKit;
#endif

namespace MonoTouchFixtures.CloudKit
{

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class CKModifyBadgeOperationTest
	{
		CKModifyBadgeOperation op = null;

		[SetUp]
		public void SetUp ()
		{
			TestRuntime.AssertXcodeVersion (6, 0);
			op = new CKModifyBadgeOperation (3);
		}

		[TearDown]
		public void TearDown ()
		{
			op?.Dispose ();
		}

		[Test]
		public void TestCompletedSetter ()
		{
			op.Completed = (e) => { Console.WriteLine ("Completed");};
			Assert.NotNull (op.Completed);
		}

		[Test]
		public void Default ()
		{
			// watchOS does not allow `init` so we need to ensure that our default .ctor
			// match the existing `init*` with null values (so we can remove it)
			using (var def = new CKModifyBadgeOperation ())
			using (var zr0 = new CKModifyBadgeOperation (0)) {
				Assert.That (def.BadgeValue, Is.EqualTo (zr0.BadgeValue), "BadgeValue");
				Assert.That (def.Completed, Is.EqualTo (zr0.Completed), "Completed");
			}
		}
	}
}
