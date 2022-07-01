package mono.com.theartofdev.edmodo.cropper;


public class CropOverlayView_CropWindowChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.theartofdev.edmodo.cropper.CropOverlayView.CropWindowChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCropWindowChanged:(Z)V:GetOnCropWindowChanged_ZHandler:TheArtOfDev.Edmodo.Cropper.CropOverlayView/ICropWindowChangeListenerInvoker, ArthurHub.AndroidImageCropper\n" +
			"";
		mono.android.Runtime.register ("TheArtOfDev.Edmodo.Cropper.CropOverlayView+ICropWindowChangeListenerImplementor, ArthurHub.AndroidImageCropper", CropOverlayView_CropWindowChangeListenerImplementor.class, __md_methods);
	}


	public CropOverlayView_CropWindowChangeListenerImplementor ()
	{
		super ();
		if (getClass () == CropOverlayView_CropWindowChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("TheArtOfDev.Edmodo.Cropper.CropOverlayView+ICropWindowChangeListenerImplementor, ArthurHub.AndroidImageCropper", "", this, new java.lang.Object[] {  });
	}


	public void onCropWindowChanged (boolean p0)
	{
		n_onCropWindowChanged (p0);
	}

	private native void n_onCropWindowChanged (boolean p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
