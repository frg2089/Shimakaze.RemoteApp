using System.Drawing.Imaging;

using Windows.Win32;
using Windows.Win32.UI.Controls;
using Windows.Win32.UI.Shell;

using System.Buffers;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace Shimakaze.RemoteApp.Web;

public class IconLoader
{
    //public static Image<Bgra32> GetImage(string path, uint index)
    //{
    //    using DestroyIconSafeHandle hIcon = PInvoke.ExtractIcon(Process.GetCurrentProcess().SafeHandle, path, index);
    //    using legacy.Icon icon = legacy.Icon.FromHandle(hIcon.DangerousGetHandle());
    //    using legacy.Bitmap bitmap = icon.ToBitmap();

    //    return From32bppArgbSystemDrawingBitmap<Bgra32>(bitmap);
    //}

    public static Icon? GetImage(string path)
    {
        SHFILEINFOW shfileinfo = new();
        unsafe
        {
            PInvoke.SHGetFileInfo(
                path,
                0,
                &shfileinfo,
                unchecked((uint)sizeof(SHFILEINFOW)),
                SHGFI_FLAGS.SHGFI_SYSICONINDEX | SHGFI_FLAGS.SHGFI_LARGEICON | SHGFI_FLAGS.SHGFI_USEFILEATTRIBUTES);
        }

        Guid guid = typeof(IImageList2).GUID;
        PInvoke.SHGetImageList(unchecked((int)PInvoke.SHIL_JUMBO), in guid, out object obj);
        if (obj is not IImageList2 imageList)
            return null;

        imageList.GetIcon(shfileinfo.iIcon, (uint)(IMAGE_LIST_DRAW_STYLE.ILD_TRANSPARENT | IMAGE_LIST_DRAW_STYLE.ILD_IMAGE), out DestroyIconSafeHandle hIcon);

        return Icon.FromHandle(hIcon.DangerousGetHandle());
    }

    //public static Image<TPixel> From32bppArgbSystemDrawingBitmap<TPixel>(legacy::Bitmap bitmap)
    //    where TPixel : unmanaged, IPixel<TPixel>
    //{
    //    int w = bitmap.Width;
    //    int h = bitmap.Height;

    //    legacy::Rectangle rectangle = new(0, 0, w, h);

    //    if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
    //    {
    //        throw new ArgumentException(
    //            $"{nameof(From32bppArgbSystemDrawingBitmap)} : pixel format should be {PixelFormat.Format32bppArgb}!",
    //            nameof(bitmap));
    //    }

    //    BitmapData data = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);
    //    Image<TPixel> image = new(w, h);
    //    try
    //    {
    //        unsafe
    //        {
    //            byte* sourcePtrBase = (byte*)data.Scan0;

    //            long sourceRowByteCount = data.Stride;
    //            long destRowByteCount = w * sizeof(Bgra32);

    //            Configuration configuration = image.GetConfiguration();

    //            using IMemoryOwner<Bgra32> workBuffer = Configuration.Default.MemoryAllocator.Allocate<Bgra32>(w);
    //            using var _1 = workBuffer.Memory.Pin();
    //            Bgra32* destPtr = (Bgra32*)_1.Pointer;

    //            for (int y = 0; y < h; y++)
    //            {
    //                Memory<TPixel> row = image.Frames.RootFrame.DangerousGetPixelRowMemory(y);

    //                byte* sourcePtr = sourcePtrBase + (data.Stride * y);

    //                Buffer.MemoryCopy(sourcePtr, destPtr, destRowByteCount, sourceRowByteCount);
    //                PixelOperations<TPixel>.Instance.FromBgra32(
    //                    configuration,
    //                    workBuffer.Memory[..w].Span,
    //                    row.Span);
    //            }
    //        }
    //    }
    //    finally
    //    {
    //        bitmap.UnlockBits(data);
    //    }
    //    return image;
    //}
}
