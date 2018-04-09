using CoreGraphics;
using System;

using UIKit;

namespace PopOverViewDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnClick(UIKit.UIButton sender)
        {
            PopoverViewController popViewController = Storyboard.InstantiateViewController("PopoverViewController") as PopoverViewController;

            popViewController.ModalPresentationStyle = UIModalPresentationStyle.Popover;
            popViewController.PreferredContentSize = new CGSize(150, 150);

            popViewController.PopoverPresentationController.SourceView = MyBtn;
            popViewController.PopoverPresentationController.SourceRect = MyBtn.Bounds;
            popViewController.PopoverPresentationController.PermittedArrowDirections = UIPopoverArrowDirection.Up;
            //popViewController.PopoverPresentationController.BackgroundColor = UIColor.White;

            popViewController.PopoverPresentationController.Delegate = new PopOverViewDelegate();
            PresentModalViewController(popViewController, true);


        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();


        }
    }

    public class PopOverViewDelegate : UIPopoverPresentationControllerDelegate
    {
        public override UIModalPresentationStyle GetAdaptivePresentationStyle(UIPresentationController forPresentationController)
        {
            return UIModalPresentationStyle.None;
        }
    }
}