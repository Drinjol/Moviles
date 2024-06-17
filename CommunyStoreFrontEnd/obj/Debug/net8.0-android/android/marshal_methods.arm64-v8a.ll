; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [343 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [686 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 252
	i64 40218994123153105, ; 1: ExCSS.dll => 0x8ee2f649ef1ed1 => 173
	i64 98382396393917666, ; 2: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 207
	i64 120698629574877762, ; 3: Mono.Android => 0x1accec39cafe242 => 171
	i64 131669012237370309, ; 4: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 212
	i64 184471870596806994, ; 5: Svg.Skia => 0x28f60305df97952 => 220
	i64 196720943101637631, ; 6: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 58
	i64 210515253464952879, ; 7: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 239
	i64 229794953483747371, ; 8: System.ValueTuple.dll => 0x330654aed93802b => 151
	i64 232391251801502327, ; 9: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 280
	i64 295915112840604065, ; 10: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 283
	i64 316157742385208084, ; 11: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 246
	i64 350667413455104241, ; 12: System.ServiceProcess.dll => 0x4ddd227954be8f1 => 132
	i64 404665707914610830, ; 13: Svg.Custom => 0x59da9513d08488e => 218
	i64 422779754995088667, ; 14: System.IO.UnmanagedMemoryStream => 0x5de03f27ab57d1b => 56
	i64 435118502366263740, ; 15: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x609d9f8f8bdb9bc => 282
	i64 502670939551102150, ; 16: System.Management.dll => 0x6f9d88e66daf4c6 => 223
	i64 545109961164950392, ; 17: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 315
	i64 560278790331054453, ; 18: System.Reflection.Primitives => 0x7c6829760de3975 => 95
	i64 634308326490598313, ; 19: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 265
	i64 649145001856603771, ; 20: System.Security.SecureString => 0x90239f09b62167b => 129
	i64 750875890346172408, ; 21: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 145
	i64 798450721097591769, ; 22: Xamarin.AndroidX.Collection.Ktx.dll => 0xb14aab351ad2bd9 => 240
	i64 799765834175365804, ; 23: System.ComponentModel.dll => 0xb1956c9f18442ac => 18
	i64 849051935479314978, ; 24: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 318
	i64 872800313462103108, ; 25: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 251
	i64 895210737996778430, ; 26: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0xc6c6d6c5569cbbe => 266
	i64 901995307004200655, ; 27: Plugin.FilePicker.dll => 0xc8487f3e70e06cf => 307
	i64 940822596282819491, ; 28: System.Transactions => 0xd0e792aa81923a3 => 150
	i64 960778385402502048, ; 29: System.Runtime.Handles.dll => 0xd555ed9e1ca1ba0 => 104
	i64 1010599046655515943, ; 30: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 95
	i64 1120440138749646132, ; 31: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 295
	i64 1121665720830085036, ; 32: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 326
	i64 1148967669621400176, ; 33: Microsoft.Azure.Storage.Common => 0xff1f4020e312270 => 197
	i64 1268860745194512059, ; 34: System.Drawing.dll => 0x119be62002c19ebb => 36
	i64 1301626418029409250, ; 35: System.Diagnostics.FileVersionInfo => 0x12104e54b4e833e2 => 28
	i64 1315114680217950157, ; 36: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 235
	i64 1369545283391376210, ; 37: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 273
	i64 1404195534211153682, ; 38: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 50
	i64 1425944114962822056, ; 39: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 115
	i64 1476839205573959279, ; 40: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 70
	i64 1486715745332614827, ; 41: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 209
	i64 1492954217099365037, ; 42: System.Net.HttpListener => 0x14b809f350210aad => 65
	i64 1513467482682125403, ; 43: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 170
	i64 1537168428375924959, ; 44: System.Threading.Thread.dll => 0x15551e8a954ae0df => 145
	i64 1556147632182429976, ; 45: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 324
	i64 1576750169145655260, ; 46: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x15e1bdecc376bfdc => 294
	i64 1624659445732251991, ; 47: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 234
	i64 1628611045998245443, ; 48: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 269
	i64 1636321030536304333, ; 49: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 259
	i64 1651782184287836205, ; 50: System.Globalization.Calendars => 0x16ec4f2524cb982d => 40
	i64 1659332977923810219, ; 51: System.Reflection.DispatchProxy => 0x1707228d493d63ab => 89
	i64 1682513316613008342, ; 52: System.Net.dll => 0x17597cf276952bd6 => 81
	i64 1731380447121279447, ; 53: Newtonsoft.Json => 0x18071957e9b889d7 => 214
	i64 1735388228521408345, ; 54: System.Net.Mail.dll => 0x181556663c69b759 => 66
	i64 1743969030606105336, ; 55: System.Memory.dll => 0x1833d297e88f2af8 => 62
	i64 1767386781656293639, ; 56: System.Private.Uri.dll => 0x188704e9f5582107 => 86
	i64 1795316252682057001, ; 57: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 233
	i64 1825687700144851180, ; 58: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 106
	i64 1835311033149317475, ; 59: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 314
	i64 1836611346387731153, ; 60: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 280
	i64 1854145951182283680, ; 61: System.Runtime.CompilerServices.VisualC => 0x19bb3feb3df2e3a0 => 102
	i64 1875417405349196092, ; 62: System.Drawing.Primitives => 0x1a06d2319b6c713c => 35
	i64 1875917498431009007, ; 63: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 230
	i64 1881198190668717030, ; 64: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 336
	i64 1897575647115118287, ; 65: Xamarin.AndroidX.Security.SecurityCrypto => 0x1a558aff4cba86cf => 282
	i64 1920760634179481754, ; 66: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 210
	i64 1959996714666907089, ; 67: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 336
	i64 1972385128188460614, ; 68: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 119
	i64 1981742497975770890, ; 69: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 267
	i64 1983698669889758782, ; 70: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 310
	i64 2019660174692588140, ; 71: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 328
	i64 2038176078398990831, ; 72: FFImageLoading.Compat => 0x1c490e5836aba9ef => 174
	i64 2040001226662520565, ; 73: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 142
	i64 2062890601515140263, ; 74: System.Threading.Tasks.Dataflow => 0x1ca0dc1289cd44a7 => 141
	i64 2064708342624596306, ; 75: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 303
	i64 2080945842184875448, ; 76: System.IO.MemoryMappedFiles => 0x1ce10137d8416db8 => 53
	i64 2102659300918482391, ; 77: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 35
	i64 2106033277907880740, ; 78: System.Threading.Tasks.Dataflow.dll => 0x1d3a221ba6d9cb24 => 141
	i64 2133195048986300728, ; 79: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 214
	i64 2134971073272545971, ; 80: Microsoft.AspNet.SignalR.Client.dll => 0x1da0f0e12c2502b3 => 187
	i64 2136727539037051651, ; 81: FFImageLoading.Compat.Maui => 0x1da72e603a191b03 => 175
	i64 2165310824878145998, ; 82: Xamarin.Android.Glide.GifDecoder => 0x1e0cbab9112b81ce => 227
	i64 2165725771938924357, ; 83: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 237
	i64 2188974421706709258, ; 84: SkiaSharp.HarfBuzz.dll => 0x1e60cca38c3e990a => 217
	i64 2200176636225660136, ; 85: Microsoft.Extensions.Logging.Debug.dll => 0x1e8898fe5d5824e8 => 205
	i64 2262844636196693701, ; 86: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 251
	i64 2287834202362508563, ; 87: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 8
	i64 2287887973817120656, ; 88: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 14
	i64 2302323944321350744, ; 89: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 332
	i64 2304837677853103545, ; 90: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0x1ffc6da80d5ed5b9 => 279
	i64 2315304989185124968, ; 91: System.IO.FileSystem.dll => 0x20219d9ee311aa68 => 51
	i64 2329709569556905518, ; 92: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 262
	i64 2335503487726329082, ; 93: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 136
	i64 2337758774805907496, ; 94: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 101
	i64 2470498323731680442, ; 95: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 244
	i64 2479423007379663237, ; 96: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 289
	i64 2497223385847772520, ; 97: System.Runtime => 0x22a7eb7046413568 => 116
	i64 2547086958574651984, ; 98: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 228
	i64 2592350477072141967, ; 99: System.Xml.dll => 0x23f9e10627330e8f => 163
	i64 2602673633151553063, ; 100: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 335
	i64 2624866290265602282, ; 101: mscorlib.dll => 0x246d65fbde2db8ea => 166
	i64 2632269733008246987, ; 102: System.Net.NameResolution => 0x2487b36034f808cb => 67
	i64 2656907746661064104, ; 103: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 200
	i64 2662981627730767622, ; 104: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 310
	i64 2706075432581334785, ; 105: System.Net.WebSockets => 0x258de944be6c0701 => 80
	i64 2721478136117819115, ; 106: FFImageLoading.Compat.Svg.Maui.dll => 0x25c4a1f21f4b76eb => 177
	i64 2783046991838674048, ; 107: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 101
	i64 2787234703088983483, ; 108: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 284
	i64 2812926542227278819, ; 109: Google.Apis.Core.dll => 0x270985c960b98be3 => 183
	i64 2815524396660695947, ; 110: System.Security.AccessControl => 0x2712c0857f68238b => 117
	i64 2895129759130297543, ; 111: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 315
	i64 2923871038697555247, ; 112: Jsr305Binding => 0x2893ad37e69ec52f => 296
	i64 3017136373564924869, ; 113: System.Net.WebProxy => 0x29df058bd93f63c5 => 78
	i64 3017704767998173186, ; 114: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 295
	i64 3106852385031680087, ; 115: System.Runtime.Serialization.Xml => 0x2b1dc1c88b637057 => 114
	i64 3110390492489056344, ; 116: System.Security.Cryptography.Csp.dll => 0x2b2a53ac61900058 => 121
	i64 3135773902340015556, ; 117: System.IO.FileSystem.DriveInfo.dll => 0x2b8481c008eac5c4 => 48
	i64 3149515290929572490, ; 118: Google.Apis.Drive.v3 => 0x2bb553786284aa8a => 184
	i64 3281594302220646930, ; 119: System.Security.Principal => 0x2d8a90a198ceba12 => 128
	i64 3289520064315143713, ; 120: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 260
	i64 3303437397778967116, ; 121: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 231
	i64 3311221304742556517, ; 122: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 82
	i64 3324483813344587579, ; 123: FFImageLoading.Compat.Transformations => 0x2e22f06a13f0af3b => 178
	i64 3325875462027654285, ; 124: System.Runtime.Numerics => 0x2e27e21c8958b48d => 110
	i64 3328853167529574890, ; 125: System.Net.Sockets.dll => 0x2e327651a008c1ea => 75
	i64 3344514922410554693, ; 126: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 306
	i64 3429672777697402584, ; 127: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 212
	i64 3437845325506641314, ; 128: System.IO.MemoryMappedFiles.dll => 0x2fb5ae1beb8f7da2 => 53
	i64 3461602852075779363, ; 129: SkiaSharp.HarfBuzz => 0x300a15741f74b523 => 217
	i64 3493805808809882663, ; 130: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 286
	i64 3494946837667399002, ; 131: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 198
	i64 3508450208084372758, ; 132: System.Net.Ping => 0x30b084e02d03ad16 => 69
	i64 3522470458906976663, ; 133: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 285
	i64 3531994851595924923, ; 134: System.Numerics => 0x31042a9aade235bb => 83
	i64 3551103847008531295, ; 135: System.Private.CoreLib.dll => 0x31480e226177735f => 172
	i64 3567343442040498961, ; 136: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 330
	i64 3571415421602489686, ; 137: System.Runtime.dll => 0x319037675df7e556 => 116
	i64 3638003163729360188, ; 138: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 199
	i64 3647754201059316852, ; 139: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 156
	i64 3655542548057982301, ; 140: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 198
	i64 3658489898830683555, ; 141: Svg.Skia.dll => 0x32c5912df2285da3 => 220
	i64 3659371656528649588, ; 142: Xamarin.Android.Glide.Annotations => 0x32c8b3222885dd74 => 225
	i64 3716579019761409177, ; 143: netstandard.dll => 0x3393f0ed5c8c5c99 => 167
	i64 3727469159507183293, ; 144: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 278
	i64 3772598417116884899, ; 145: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 252
	i64 3783726507060260521, ; 146: Microsoft.AspNetCore.SignalR.Common.dll => 0x34827f360c8e6ea9 => 193
	i64 3869221888984012293, ; 147: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 203
	i64 3869649043256705283, ; 148: System.Diagnostics.Tools => 0x35b3c14d74bf0103 => 32
	i64 3890352374528606784, ; 149: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 210
	i64 3919223565570527920, ; 150: System.Security.Cryptography.Encoding => 0x3663e111652bd2b0 => 122
	i64 3933965368022646939, ; 151: System.Net.Requests => 0x369840a8bfadc09b => 72
	i64 3966267475168208030, ; 152: System.Memory => 0x370b03412596249e => 62
	i64 4006972109285359177, ; 153: System.Xml.XmlDocument => 0x379b9fe74ed9fe49 => 161
	i64 4009997192427317104, ; 154: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 113
	i64 4056584864658557221, ; 155: Google.Apis.Auth => 0x384be27113330925 => 182
	i64 4073500526318903918, ; 156: System.Private.Xml.dll => 0x3887fb25779ae26e => 88
	i64 4073631083018132676, ; 157: Microsoft.Maui.Controls.Compatibility.dll => 0x388871e311491cc4 => 208
	i64 4120493066591692148, ; 158: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 341
	i64 4148881117810174540, ; 159: System.Runtime.InteropServices.JavaScript.dll => 0x3993c9651a66aa4c => 105
	i64 4154383907710350974, ; 160: System.ComponentModel => 0x39a7562737acb67e => 18
	i64 4167269041631776580, ; 161: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 146
	i64 4168469861834746866, ; 162: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 118
	i64 4187479170553454871, ; 163: System.Linq.Expressions => 0x3a1cea1e912fa117 => 58
	i64 4201423742386704971, ; 164: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 246
	i64 4205801962323029395, ; 165: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 17
	i64 4235503420553921860, ; 166: System.IO.IsolatedStorage.dll => 0x3ac787eb9b118544 => 52
	i64 4282138915307457788, ; 167: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 92
	i64 4356591372459378815, ; 168: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 338
	i64 4373617458794931033, ; 169: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 55
	i64 4397634830160618470, ; 170: System.Security.SecureString.dll => 0x3d0789940f9be3e6 => 129
	i64 4477672992252076438, ; 171: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 152
	i64 4484706122338676047, ; 172: System.Globalization.Extensions.dll => 0x3e3ce07510042d4f => 41
	i64 4533124835995628778, ; 173: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 92
	i64 4636684751163556186, ; 174: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 290
	i64 4672453897036726049, ; 175: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 50
	i64 4679594760078841447, ; 176: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 308
	i64 4716677666592453464, ; 177: System.Xml.XmlSerializer => 0x417501590542f358 => 162
	i64 4743821336939966868, ; 178: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 13
	i64 4759461199762736555, ; 179: Xamarin.AndroidX.Lifecycle.Process.dll => 0x420d00be961cc5ab => 264
	i64 4794310189461587505, ; 180: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 228
	i64 4795410492532947900, ; 181: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 285
	i64 4809057822547766521, ; 182: System.Drawing => 0x42bd349c3145ecf9 => 36
	i64 4814660307502931973, ; 183: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 67
	i64 4853321196694829351, ; 184: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 109
	i64 5055365687667823624, ; 185: Xamarin.AndroidX.Activity.Ktx.dll => 0x4628444ef7239408 => 229
	i64 5081566143765835342, ; 186: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 99
	i64 5099468265966638712, ; 187: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 99
	i64 5103417709280584325, ; 188: System.Collections.Specialized => 0x46d2fb5e161b6285 => 11
	i64 5182934613077526976, ; 189: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 11
	i64 5205316157927637098, ; 190: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 271
	i64 5244375036463807528, ; 191: System.Diagnostics.Contracts.dll => 0x48c7c34f4d59fc28 => 25
	i64 5262971552273843408, ; 192: System.Security.Principal.dll => 0x4909d4be0c44c4d0 => 128
	i64 5278787618751394462, ; 193: System.Net.WebClient.dll => 0x4942055efc68329e => 76
	i64 5280980186044710147, ; 194: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x4949cf7fd7123d03 => 263
	i64 5290786973231294105, ; 195: System.Runtime.Loader => 0x496ca6b869b72699 => 109
	i64 5306356071055648198, ; 196: Svg.Model.dll => 0x49a3f6bb7b0265c6 => 219
	i64 5376510917114486089, ; 197: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 289
	i64 5408338804355907810, ; 198: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 287
	i64 5423376490970181369, ; 199: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 106
	i64 5440320908473006344, ; 200: Microsoft.VisualBasic.Core => 0x4b7fe70acda9f908 => 2
	i64 5446034149219586269, ; 201: System.Diagnostics.Debug => 0x4b94333452e150dd => 26
	i64 5451019430259338467, ; 202: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 242
	i64 5457765010617926378, ; 203: System.Xml.Serialization => 0x4bbde05c557002ea => 157
	i64 5471532531798518949, ; 204: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 334
	i64 5507995362134886206, ; 205: System.Core.dll => 0x4c705499688c873e => 21
	i64 5522859530602327440, ; 206: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 337
	i64 5527431512186326818, ; 207: System.IO.FileSystem.Primitives.dll => 0x4cb561acbc2a8f22 => 49
	i64 5570799893513421663, ; 208: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 43
	i64 5573260873512690141, ; 209: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 126
	i64 5574231584441077149, ; 210: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 232
	i64 5591791169662171124, ; 211: System.Linq.Parallel => 0x4d9a087135e137f4 => 59
	i64 5650097808083101034, ; 212: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 119
	i64 5665389054145784248, ; 213: Google.Apis.Core => 0x4e9f815406bee9b8 => 183
	i64 5692067934154308417, ; 214: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 292
	i64 5724799082821825042, ; 215: Xamarin.AndroidX.ExifInterface => 0x4f72926f3e13b212 => 255
	i64 5757522595884336624, ; 216: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 241
	i64 5783556987928984683, ; 217: Microsoft.VisualBasic => 0x504352701bbc3c6b => 3
	i64 5817425494286445158, ; 218: FFImageLoading.Compat.Transformations.dll => 0x50bba5aa3e3eaa66 => 178
	i64 5896680224035167651, ; 219: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 261
	i64 5933073409418847282, ; 220: Microsoft.Azure.Storage.Blob.dll => 0x525682d4c2b9e432 => 196
	i64 5959344983920014087, ; 221: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x52b3d8b05c8ef307 => 281
	i64 5979151488806146654, ; 222: System.Formats.Asn1 => 0x52fa3699a489d25e => 38
	i64 5984759512290286505, ; 223: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 124
	i64 6014447449592687183, ; 224: Microsoft.AspNetCore.Http.Connections.Common.dll => 0x53779c16e939ea4f => 190
	i64 6034224070161570862, ; 225: Microsoft.AspNetCore.SignalR.Client.dll => 0x53bdded235179c2e => 191
	i64 6068057819846744445, ; 226: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 331
	i64 6102788177522843259, ; 227: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0x54b1758374b3de7b => 281
	i64 6165202358202206911, ; 228: Microsoft.Azure.Storage.Blob => 0x558f32e1510b0abf => 196
	i64 6200764641006662125, ; 229: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 331
	i64 6222399776351216807, ; 230: System.Text.Json.dll => 0x565a67a0ffe264a7 => 137
	i64 6251069312384999852, ; 231: System.Transactions.Local => 0x56c0426b870da1ac => 149
	i64 6278736998281604212, ; 232: System.Private.DataContractSerialization => 0x57228e08a4ad6c74 => 85
	i64 6284145129771520194, ; 233: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 90
	i64 6319713645133255417, ; 234: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 265
	i64 6354612700029906737, ; 235: ShimSkiaSharp.dll => 0x58301e951e77ef31 => 215
	i64 6357457916754632952, ; 236: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 342
	i64 6363787360044722189, ; 237: ShimSkiaSharp => 0x5850b6e31d96280d => 215
	i64 6401687960814735282, ; 238: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 262
	i64 6478287442656530074, ; 239: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 319
	i64 6504860066809920875, ; 240: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 237
	i64 6548213210057960872, ; 241: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 248
	i64 6557084851308642443, ; 242: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 293
	i64 6560151584539558821, ; 243: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 206
	i64 6580586772946716121, ; 244: Microsoft.Azure.KeyVault.Core => 0x5b52f0cdf71f85d9 => 195
	i64 6589202984700901502, ; 245: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 298
	i64 6591971792923354531, ; 246: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x5b7b636b7e9765a3 => 263
	i64 6617685658146568858, ; 247: System.Text.Encoding.CodePages => 0x5bd6be0b4905fa9a => 133
	i64 6671798237668743565, ; 248: SkiaSharp => 0x5c96fd260152998d => 216
	i64 6713440830605852118, ; 249: System.Reflection.TypeExtensions.dll => 0x5d2aeeddb8dd7dd6 => 96
	i64 6739853162153639747, ; 250: Microsoft.VisualBasic.dll => 0x5d88c4bde075ff43 => 3
	i64 6743165466166707109, ; 251: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 327
	i64 6772837112740759457, ; 252: System.Runtime.InteropServices.JavaScript => 0x5dfdf378527ec7a1 => 105
	i64 6777482997383978746, ; 253: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 330
	i64 6783125919820072783, ; 254: Microsoft.AspNetCore.Connections.Abstractions => 0x5e228115e59ec74f => 188
	i64 6786606130239981554, ; 255: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 33
	i64 6798329586179154312, ; 256: System.Windows => 0x5e5884bd523ca188 => 154
	i64 6814185388980153342, ; 257: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 158
	i64 6876862101832370452, ; 258: System.Xml.Linq => 0x5f6f85a57d108914 => 155
	i64 6894844156784520562, ; 259: System.Numerics.Vectors => 0x5faf683aead1ad72 => 82
	i64 6956410392315992198, ; 260: FFImageLoading.Compat.Maui.dll => 0x608a226529d49886 => 175
	i64 6987056692196838363, ; 261: System.Management => 0x60f7030ae3e88bdb => 223
	i64 7011053663211085209, ; 262: Xamarin.AndroidX.Fragment.Ktx => 0x614c442918e5dd99 => 257
	i64 7017588408768804231, ; 263: Microsoft.AspNetCore.SignalR.Protocols.Json => 0x61637b7a1c903587 => 194
	i64 7060896174307865760, ; 264: System.Threading.Tasks.Parallel.dll => 0x61fd57a90988f4a0 => 143
	i64 7083547580668757502, ; 265: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 87
	i64 7101497697220435230, ; 266: System.Configuration => 0x628d9687c0141d1e => 19
	i64 7103753931438454322, ; 267: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 258
	i64 7112547816752919026, ; 268: System.IO.FileSystem => 0x62b4d88e3189b1f2 => 51
	i64 7192745174564810625, ; 269: Xamarin.Android.Glide.GifDecoder.dll => 0x63d1c3a0a1d72f81 => 227
	i64 7220009545223068405, ; 270: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 334
	i64 7270811800166795866, ; 271: System.Linq => 0x64e71ccf51a90a5a => 61
	i64 7299370801165188114, ; 272: System.IO.Pipes.AccessControl.dll => 0x654c9311e74f3c12 => 54
	i64 7316205155833392065, ; 273: Microsoft.Win32.Primitives => 0x658861d38954abc1 => 4
	i64 7338192458477945005, ; 274: System.Reflection => 0x65d67f295d0740ad => 97
	i64 7349431895026339542, ; 275: Xamarin.Android.Glide.DiskLruCache => 0x65fe6d5e9bf88ed6 => 226
	i64 7377312882064240630, ; 276: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 17
	i64 7488575175965059935, ; 277: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 155
	i64 7489048572193775167, ; 278: System.ObjectModel => 0x67ee71ff6b419e3f => 84
	i64 7509866036550816153, ; 279: Plugin.FilePicker => 0x6838675f0b61d199 => 307
	i64 7576191739629449958, ; 280: Microsoft.AspNet.SignalR.Client => 0x69240a3f2edcb2e6 => 187
	i64 7592577537120840276, ; 281: System.Diagnostics.Process => 0x695e410af5b2aa54 => 29
	i64 7637303409920963731, ; 282: System.IO.Compression.ZipFile.dll => 0x69fd26fcb637f493 => 45
	i64 7640829051849446879, ; 283: Fizzler => 0x6a09ad8a30f895df => 180
	i64 7654504624184590948, ; 284: System.Net.Http => 0x6a3a4366801b8264 => 64
	i64 7694700312542370399, ; 285: System.Net.Mail => 0x6ac9112a7e2cda5f => 66
	i64 7708790323521193081, ; 286: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 325
	i64 7714652370974252055, ; 287: System.Private.CoreLib => 0x6b0ff375198b9c17 => 172
	i64 7725404731275645577, ; 288: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x6b3626ac11ce9289 => 266
	i64 7735176074855944702, ; 289: Microsoft.CSharp => 0x6b58dda848e391fe => 1
	i64 7735352534559001595, ; 290: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 301
	i64 7791074099216502080, ; 291: System.IO.FileSystem.AccessControl.dll => 0x6c1f749d468bcd40 => 47
	i64 7820441508502274321, ; 292: System.Data => 0x6c87ca1e14ff8111 => 24
	i64 7836164640616011524, ; 293: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 234
	i64 8025517457475554965, ; 294: WindowsBase => 0x6f605d9b4786ce95 => 165
	i64 8031450141206250471, ; 295: System.Runtime.Intrinsics.dll => 0x6f757159d9dc03e7 => 108
	i64 8064050204834738623, ; 296: System.Collections.dll => 0x6fe942efa61731bf => 12
	i64 8083354569033831015, ; 297: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 260
	i64 8085230611270010360, ; 298: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 63
	i64 8087206902342787202, ; 299: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 27
	i64 8103644804370223335, ; 300: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 23
	i64 8113615946733131500, ; 301: System.Reflection.Extensions => 0x70995ab73cf916ec => 93
	i64 8167236081217502503, ; 302: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 168
	i64 8185542183669246576, ; 303: System.Collections => 0x7198e33f4794aa70 => 12
	i64 8187640529827139739, ; 304: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 305
	i64 8195406069771384777, ; 305: Firebase.Storage.dll => 0x71bbee663acdb7c9 => 179
	i64 8243855692487634729, ; 306: Microsoft.AspNetCore.SignalR.Protocols.Json.dll => 0x72680f13124eaf29 => 194
	i64 8246048515196606205, ; 307: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 213
	i64 8264926008854159966, ; 308: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 29
	i64 8290740647658429042, ; 309: System.Runtime.Extensions => 0x730ea0b15c929a72 => 103
	i64 8318905602908530212, ; 310: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 14
	i64 8368701292315763008, ; 311: System.Security.Cryptography => 0x7423997c6fd56140 => 126
	i64 8398329775253868912, ; 312: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 243
	i64 8400357532724379117, ; 313: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 275
	i64 8410671156615598628, ; 314: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 91
	i64 8426919725312979251, ; 315: Xamarin.AndroidX.Lifecycle.Process => 0x74f26ed7aa033133 => 264
	i64 8471458099622282839, ; 316: CommunyStoreFrontEnd => 0x7590aa4205978657 => 0
	i64 8518412311883997971, ; 317: System.Collections.Immutable => 0x76377add7c28e313 => 9
	i64 8563666267364444763, ; 318: System.Private.Uri => 0x76d841191140ca5b => 86
	i64 8598790081731763592, ; 319: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x77550a055fc61d88 => 254
	i64 8601935802264776013, ; 320: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 287
	i64 8614108721271900878, ; 321: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 329
	i64 8623059219396073920, ; 322: System.Net.Quic.dll => 0x77ab42ac514299c0 => 71
	i64 8626175481042262068, ; 323: Java.Interop => 0x77b654e585b55834 => 168
	i64 8638972117149407195, ; 324: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 1
	i64 8639588376636138208, ; 325: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 274
	i64 8648495978913578441, ; 326: Microsoft.Win32.Registry.dll => 0x7805a1456889bdc9 => 5
	i64 8677882282824630478, ; 327: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 329
	i64 8684531736582871431, ; 328: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 44
	i64 8725526185868997716, ; 329: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 27
	i64 8834232125107082525, ; 330: ExCSS => 0x7a997f4fe05a151d => 173
	i64 8853378295825400934, ; 331: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 302
	i64 8941376889969657626, ; 332: System.Xml.XDocument => 0x7c1626e87187471a => 158
	i64 8951477988056063522, ; 333: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 277
	i64 8954753533646919997, ; 334: System.Runtime.Serialization.Json => 0x7c45ace50032d93d => 112
	i64 9045785047181495996, ; 335: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 339
	i64 9138683372487561558, ; 336: System.Security.Cryptography.Csp => 0x7ed3201bc3e3d156 => 121
	i64 9248940107580716988, ; 337: Svg.Custom.dll => 0x805ad6065d3637bc => 218
	i64 9312692141327339315, ; 338: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 292
	i64 9324707631942237306, ; 339: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 233
	i64 9468215723722196442, ; 340: System.Xml.XPath.XDocument.dll => 0x8365dc09353ac5da => 159
	i64 9554839972845591462, ; 341: System.ServiceModel.Web => 0x84999c54e32a1ba6 => 131
	i64 9575902398040817096, ; 342: Xamarin.Google.Crypto.Tink.Android.dll => 0x84e4707ee708bdc8 => 297
	i64 9584643793929893533, ; 343: System.IO.dll => 0x85037ebfbbd7f69d => 57
	i64 9659729154652888475, ; 344: System.Text.RegularExpressions => 0x860e407c9991dd9b => 138
	i64 9662334977499516867, ; 345: System.Numerics.dll => 0x8617827802b0cfc3 => 83
	i64 9667360217193089419, ; 346: System.Diagnostics.StackTrace => 0x86295ce5cd89898b => 30
	i64 9678050649315576968, ; 347: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 244
	i64 9702891218465930390, ; 348: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 10
	i64 9780093022148426479, ; 349: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x87b9dec9576efaef => 294
	i64 9808709177481450983, ; 350: Mono.Android.dll => 0x881f890734e555e7 => 171
	i64 9825649861376906464, ; 351: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 241
	i64 9834056768316610435, ; 352: System.Transactions.dll => 0x8879968718899783 => 150
	i64 9836529246295212050, ; 353: System.Reflection.Metadata => 0x88825f3bbc2ac012 => 94
	i64 9907349773706910547, ; 354: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x897dfa20b758db53 => 254
	i64 9933555792566666578, ; 355: System.Linq.Queryable.dll => 0x89db145cf475c552 => 60
	i64 9956195530459977388, ; 356: Microsoft.Maui => 0x8a2b8315b36616ac => 211
	i64 9959489431142554298, ; 357: System.CodeDom => 0x8a3736deb7825aba => 221
	i64 9974604633896246661, ; 358: System.Xml.Serialization.dll => 0x8a6cea111a59dd85 => 157
	i64 9991543690424095600, ; 359: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 314
	i64 10017511394021241210, ; 360: Microsoft.Extensions.Logging.Debug => 0x8b055989ae10717a => 205
	i64 10038780035334861115, ; 361: System.Net.Http.dll => 0x8b50e941206af13b => 64
	i64 10051358222726253779, ; 362: System.Private.Xml => 0x8b7d990c97ccccd3 => 88
	i64 10078727084704864206, ; 363: System.Net.WebSockets.Client => 0x8bded4e257f117ce => 79
	i64 10089571585547156312, ; 364: System.IO.FileSystem.AccessControl => 0x8c055be67469bb58 => 47
	i64 10092835686693276772, ; 365: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 209
	i64 10105485790837105934, ; 366: System.Threading.Tasks.Parallel => 0x8c3de5c91d9a650e => 143
	i64 10143853363526200146, ; 367: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 311
	i64 10226222362177979215, ; 368: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 303
	i64 10226498071391929720, ; 369: Microsoft.Extensions.Features => 0x8debd1d049888578 => 202
	i64 10229024438826829339, ; 370: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 248
	i64 10236703004850800690, ; 371: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 74
	i64 10245369515835430794, ; 372: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 91
	i64 10321854143672141184, ; 373: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 300
	i64 10360651442923773544, ; 374: System.Text.Encoding => 0x8fc86d98211c1e68 => 135
	i64 10364469296367737616, ; 375: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 90
	i64 10376576884623852283, ; 376: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 286
	i64 10406448008575299332, ; 377: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 306
	i64 10430153318873392755, ; 378: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 245
	i64 10506226065143327199, ; 379: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 309
	i64 10546663366131771576, ; 380: System.Runtime.Serialization.Json.dll => 0x925d4673efe8e8b8 => 112
	i64 10566960649245365243, ; 381: System.Globalization.dll => 0x92a562b96dcd13fb => 42
	i64 10595762989148858956, ; 382: System.Xml.XPath.XDocument => 0x930bb64cc472ea4c => 159
	i64 10670374202010151210, ; 383: Microsoft.Win32.Primitives.dll => 0x9414c8cd7b4ea92a => 4
	i64 10714184849103829812, ; 384: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 103
	i64 10785150219063592792, ; 385: System.Net.Primitives => 0x95ac8cfb68830758 => 70
	i64 10794455402127920989, ; 386: FFImageLoading.Compat.dll => 0x95cd9bff2ba18f5d => 174
	i64 10822644899632537592, ; 387: System.Linq.Queryable => 0x9631c23204ca5ff8 => 60
	i64 10830817578243619689, ; 388: System.Formats.Tar => 0x964ecb340a447b69 => 39
	i64 10847732767863316357, ; 389: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 235
	i64 10899834349646441345, ; 390: System.Web => 0x9743fd975946eb81 => 153
	i64 10943875058216066601, ; 391: System.IO.UnmanagedMemoryStream.dll => 0x97e07461df39de29 => 56
	i64 10964653383833615866, ; 392: System.Diagnostics.Tracing => 0x982a4628ccaffdfa => 34
	i64 11002576679268595294, ; 393: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 204
	i64 11009005086950030778, ; 394: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 211
	i64 11019817191295005410, ; 395: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 232
	i64 11023048688141570732, ; 396: System.Core => 0x98f9bc61168392ac => 21
	i64 11037814507248023548, ; 397: System.Xml => 0x992e31d0412bf7fc => 163
	i64 11071824625609515081, ; 398: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 298
	i64 11103970607964515343, ; 399: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 320
	i64 11136029745144976707, ; 400: Jsr305Binding.dll => 0x9a8b200d4f8cd543 => 296
	i64 11162124722117608902, ; 401: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 291
	i64 11188319605227840848, ; 402: System.Threading.Overlapped => 0x9b44e5671724e550 => 140
	i64 11216600183782743182, ; 403: Svg.Model => 0x9ba95e7065f39c8e => 219
	i64 11220793807500858938, ; 404: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 323
	i64 11226290749488709958, ; 405: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 206
	i64 11235648312900863002, ; 406: System.Reflection.DispatchProxy.dll => 0x9bed0a9c8fac441a => 89
	i64 11329751333533450475, ; 407: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 147
	i64 11340910727871153756, ; 408: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 247
	i64 11347436699239206956, ; 409: System.Xml.XmlSerializer.dll => 0x9d7a318e8162502c => 162
	i64 11392833485892708388, ; 410: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 276
	i64 11432101114902388181, ; 411: System.AppContext => 0x9ea6fb64e61a9dd5 => 6
	i64 11446671985764974897, ; 412: Mono.Android.Export => 0x9edabf8623efc131 => 169
	i64 11448276831755070604, ; 413: System.Diagnostics.TextWriterTraceListener => 0x9ee0731f77186c8c => 31
	i64 11485890710487134646, ; 414: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 107
	i64 11508496261504176197, ; 415: Xamarin.AndroidX.Fragment.Ktx.dll => 0x9fb664600dde1045 => 257
	i64 11513602507638267977, ; 416: System.IO.Pipelines.dll => 0x9fc8887aa0d36049 => 222
	i64 11518296021396496455, ; 417: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 321
	i64 11529969570048099689, ; 418: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 291
	i64 11530571088791430846, ; 419: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 203
	i64 11580057168383206117, ; 420: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 230
	i64 11591352189662810718, ; 421: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 284
	i64 11597940890313164233, ; 422: netstandard => 0xa0f429ca8d1805c9 => 167
	i64 11672361001936329215, ; 423: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 258
	i64 11692977985522001935, ; 424: System.Threading.Overlapped.dll => 0xa245cd869980680f => 140
	i64 11705530742807338875, ; 425: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 317
	i64 11707554492040141440, ; 426: System.Linq.Parallel.dll => 0xa27996c7fe94da80 => 59
	i64 11743665907891708234, ; 427: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 144
	i64 11967721421130449846, ; 428: Google.Apis.Drive.v3.dll => 0xa615e3398d5043b6 => 184
	i64 11991047634523762324, ; 429: System.Net => 0xa668c24ad493ae94 => 81
	i64 12040886584167504988, ; 430: System.Net.ServicePoint => 0xa719d28d8e121c5c => 74
	i64 12063623837170009990, ; 431: System.Security => 0xa76a99f6ce740786 => 130
	i64 12096697103934194533, ; 432: System.Diagnostics.Contracts => 0xa7e019eccb7e8365 => 25
	i64 12102847907131387746, ; 433: System.Buffers => 0xa7f5f40c43256f62 => 7
	i64 12123043025855404482, ; 434: System.Reflection.Extensions.dll => 0xa83db366c0e359c2 => 93
	i64 12137774235383566651, ; 435: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 288
	i64 12145679461940342714, ; 436: System.Text.Json => 0xa88e1f1ebcb62fba => 137
	i64 12191646537372739477, ; 437: Xamarin.Android.Glide.dll => 0xa9316dee7f392795 => 224
	i64 12201331334810686224, ; 438: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 113
	i64 12269460666702402136, ; 439: System.Collections.Immutable.dll => 0xaa45e178506c9258 => 9
	i64 12313367145828839434, ; 440: System.IO.Pipelines => 0xaae1de2e1c17f00a => 222
	i64 12332222936682028543, ; 441: System.Runtime.Handles => 0xab24db6c07db5dff => 104
	i64 12375446203996702057, ; 442: System.Configuration.dll => 0xabbe6ac12e2e0569 => 19
	i64 12437742355241350664, ; 443: Google.Apis.dll => 0xac9bbcc62bfdb608 => 181
	i64 12451044538927396471, ; 444: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 256
	i64 12466513435562512481, ; 445: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 270
	i64 12475113361194491050, ; 446: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 342
	i64 12487638416075308985, ; 447: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 250
	i64 12499978561737021417, ; 448: Fizzler.dll => 0xad78d846305557e9 => 180
	i64 12517810545449516888, ; 449: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 33
	i64 12538491095302438457, ; 450: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 238
	i64 12550732019250633519, ; 451: System.IO.Compression => 0xae2d28465e8e1b2f => 46
	i64 12681088699309157496, ; 452: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 322
	i64 12699999919562409296, ; 453: System.Diagnostics.StackTrace.dll => 0xb03f76a3ad01c550 => 30
	i64 12700543734426720211, ; 454: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 239
	i64 12708238894395270091, ; 455: System.IO => 0xb05cbbf17d3ba3cb => 57
	i64 12708922737231849740, ; 456: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 134
	i64 12717050818822477433, ; 457: System.Runtime.Serialization.Xml.dll => 0xb07c0a5786811679 => 114
	i64 12753841065332862057, ; 458: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 293
	i64 12823819093633476069, ; 459: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 335
	i64 12828192437253469131, ; 460: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 304
	i64 12835242264250840079, ; 461: System.IO.Pipes => 0xb21ff0d5d6c0740f => 55
	i64 12843321153144804894, ; 462: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 207
	i64 12843770487262409629, ; 463: System.AppContext.dll => 0xb23e3d357debf39d => 6
	i64 12859557719246324186, ; 464: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 77
	i64 12942564684163400157, ; 465: FFImageLoading.Compat.Svg.Maui => 0xb39d3a01f21341dd => 177
	i64 12958614573187252691, ; 466: Google.Apis => 0xb3d63f4bf006c1d3 => 181
	i64 12982280885948128408, ; 467: Xamarin.AndroidX.CustomView.PoolingContainer => 0xb42a53aec5481c98 => 249
	i64 13034532390708954583, ; 468: FFImageLoading.Compat.Svg => 0xb4e3f6264187c5d7 => 176
	i64 13068258254871114833, ; 469: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 111
	i64 13106026140046202731, ; 470: HarfBuzzSharp.dll => 0xb5e1f555ee70176b => 186
	i64 13129914918964716986, ; 471: Xamarin.AndroidX.Emoji2.dll => 0xb636d40db3fe65ba => 253
	i64 13173818576982874404, ; 472: System.Runtime.CompilerServices.VisualC.dll => 0xb6d2ce32a8819924 => 102
	i64 13221551921002590604, ; 473: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 309
	i64 13222659110913276082, ; 474: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 323
	i64 13295219713260136977, ; 475: Microsoft.AspNetCore.Http.Connections.Client => 0xb8821be35ba42a11 => 189
	i64 13343850469010654401, ; 476: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 170
	i64 13370592475155966277, ; 477: System.Runtime.Serialization => 0xb98de304062ea945 => 115
	i64 13381594904270902445, ; 478: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 317
	i64 13401370062847626945, ; 479: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 288
	i64 13404347523447273790, ; 480: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 243
	i64 13428779960367410341, ; 481: Microsoft.AspNetCore.SignalR.Client.Core.dll => 0xba5c9c39a8956ca5 => 192
	i64 13431476299110033919, ; 482: System.Net.WebClient => 0xba663087f18829ff => 76
	i64 13454009404024712428, ; 483: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 299
	i64 13463706743370286408, ; 484: System.Private.DataContractSerialization.dll => 0xbad8b1f3069e0548 => 85
	i64 13465488254036897740, ; 485: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 301
	i64 13467053111158216594, ; 486: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 337
	i64 13491513212026656886, ; 487: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 236
	i64 13507158622933143565, ; 488: Microsoft.Azure.KeyVault.Core.dll => 0xbb7311341cc8d00d => 195
	i64 13540124433173649601, ; 489: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 338
	i64 13545416393490209236, ; 490: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 321
	i64 13572454107664307259, ; 491: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 278
	i64 13578472628727169633, ; 492: System.Xml.XPath => 0xbc706ce9fba5c261 => 160
	i64 13580399111273692417, ; 493: Microsoft.VisualBasic.Core.dll => 0xbc77450a277fbd01 => 2
	i64 13621154251410165619, ; 494: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0xbd080f9faa1acf73 => 249
	i64 13647894001087880694, ; 495: System.Data.dll => 0xbd670f48cb071df6 => 24
	i64 13675589307506966157, ; 496: Xamarin.AndroidX.Activity.Ktx => 0xbdc97404d0153e8d => 229
	i64 13702626353344114072, ; 497: System.Diagnostics.Tools.dll => 0xbe29821198fb6d98 => 32
	i64 13710614125866346983, ; 498: System.Security.AccessControl.dll => 0xbe45e2e7d0b769e7 => 117
	i64 13713329104121190199, ; 499: System.Dynamic.Runtime => 0xbe4f8829f32b5737 => 37
	i64 13717397318615465333, ; 500: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 16
	i64 13755568601956062840, ; 501: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 316
	i64 13768883594457632599, ; 502: System.IO.IsolatedStorage => 0xbf14e6adb159cf57 => 52
	i64 13782512541859110153, ; 503: Google.Apis.Auth.dll => 0xbf45522249e0dd09 => 182
	i64 13814445057219246765, ; 504: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 319
	i64 13828521679616088467, ; 505: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 302
	i64 13881769479078963060, ; 506: System.Console.dll => 0xc0a5f3cade5c6774 => 20
	i64 13911222732217019342, ; 507: System.Security.Cryptography.OpenSsl.dll => 0xc10e975ec1226bce => 123
	i64 13928444506500929300, ; 508: System.Windows.dll => 0xc14bc67b8bba9714 => 154
	i64 13959074834287824816, ; 509: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 256
	i64 14075334701871371868, ; 510: System.ServiceModel.Web.dll => 0xc355a25647c5965c => 131
	i64 14100563506285742564, ; 511: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 311
	i64 14124974489674258913, ; 512: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 238
	i64 14125464355221830302, ; 513: System.Threading.dll => 0xc407bafdbc707a9e => 148
	i64 14178052285788134900, ; 514: Xamarin.Android.Glide.Annotations.dll => 0xc4c28f6f75511df4 => 225
	i64 14212104595480609394, ; 515: System.Security.Cryptography.Cng.dll => 0xc53b89d4a4518272 => 120
	i64 14220608275227875801, ; 516: System.Diagnostics.FileVersionInfo.dll => 0xc559bfe1def019d9 => 28
	i64 14226382999226559092, ; 517: System.ServiceProcess => 0xc56e43f6938e2a74 => 132
	i64 14232023429000439693, ; 518: System.Resources.Writer.dll => 0xc5824de7789ba78d => 100
	i64 14254574811015963973, ; 519: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 134
	i64 14261073672896646636, ; 520: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 276
	i64 14298246716367104064, ; 521: System.Web.dll => 0xc66d93a217f4e840 => 153
	i64 14327695147300244862, ; 522: System.Reflection.dll => 0xc6d632d338eb4d7e => 97
	i64 14327709162229390963, ; 523: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 125
	i64 14331727281556788554, ; 524: Xamarin.Android.Glide.DiskLruCache.dll => 0xc6e48607a2f7954a => 226
	i64 14332156653360558453, ; 525: Microsoft.Azure.Storage.Common.dll => 0xc6e60c8a8cceb175 => 197
	i64 14346402571976470310, ; 526: System.Net.Ping.dll => 0xc718a920f3686f26 => 69
	i64 14461014870687870182, ; 527: System.Net.Requests.dll => 0xc8afd8683afdece6 => 72
	i64 14464374589798375073, ; 528: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 332
	i64 14486659737292545672, ; 529: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 261
	i64 14495724990987328804, ; 530: Xamarin.AndroidX.ResourceInspection.Annotation => 0xc92b2913e18d5d24 => 279
	i64 14522721392235705434, ; 531: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 313
	i64 14551742072151931844, ; 532: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 136
	i64 14561513370130550166, ; 533: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 124
	i64 14574160591280636898, ; 534: System.Net.Quic => 0xca41d1d72ec783e2 => 71
	i64 14604329626201521481, ; 535: Microsoft.AspNetCore.SignalR.Client => 0xcaad006b00747d49 => 191
	i64 14622043554576106986, ; 536: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 111
	i64 14644440854989303794, ; 537: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 271
	i64 14669215534098758659, ; 538: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 200
	i64 14690985099581930927, ; 539: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 152
	i64 14705122255218365489, ; 540: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 324
	i64 14744092281598614090, ; 541: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 340
	i64 14792063746108907174, ; 542: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 299
	i64 14809184851036126845, ; 543: Microsoft.AspNetCore.SignalR.Client.Core => 0xcd84cb28db1abe7d => 192
	i64 14832630590065248058, ; 544: System.Security.Claims => 0xcdd816ef5d6e873a => 118
	i64 14852515768018889994, ; 545: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 247
	i64 14889905118082851278, ; 546: GoogleGson.dll => 0xcea391d0969961ce => 185
	i64 14892012299694389861, ; 547: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 341
	i64 14904040806490515477, ; 548: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 308
	i64 14912225920358050525, ; 549: System.Security.Principal.Windows => 0xcef2de7759506add => 127
	i64 14931407803744742450, ; 550: HarfBuzzSharp => 0xcf3704499ab36c32 => 186
	i64 14935719434541007538, ; 551: System.Text.Encoding.CodePages.dll => 0xcf4655b160b702b2 => 133
	i64 14954917835170835695, ; 552: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 201
	i64 14984936317414011727, ; 553: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 77
	i64 14987728460634540364, ; 554: System.IO.Compression.dll => 0xcfff1ba06622494c => 46
	i64 14988210264188246988, ; 555: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 250
	i64 15015154896917945444, ; 556: System.Net.Security.dll => 0xd0608bd33642dc64 => 73
	i64 15024878362326791334, ; 557: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 63
	i64 15071021337266399595, ; 558: System.Resources.Reader.dll => 0xd127060e7a18a96b => 98
	i64 15076659072870671916, ; 559: System.ObjectModel.dll => 0xd13b0d8c1620662c => 84
	i64 15111608613780139878, ; 560: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 325
	i64 15115185479366240210, ; 561: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 43
	i64 15133485256822086103, ; 562: System.Linq.dll => 0xd204f0a9127dd9d7 => 61
	i64 15150743910298169673, ; 563: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 277
	i64 15227001540531775957, ; 564: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 199
	i64 15234786388537674379, ; 565: System.Dynamic.Runtime.dll => 0xd36cd580c5be8a8b => 37
	i64 15250465174479574862, ; 566: System.Globalization.Calendars.dll => 0xd3a489469852174e => 40
	i64 15272359115529052076, ; 567: Xamarin.AndroidX.Collection.Ktx => 0xd3f251b2fb4edfac => 240
	i64 15279429628684179188, ; 568: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 305
	i64 15299439993936780255, ; 569: System.Xml.XPath.dll => 0xd452879d55019bdf => 160
	i64 15338463749992804988, ; 570: System.Resources.Reader => 0xd4dd2b839286f27c => 98
	i64 15370334346939861994, ; 571: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 245
	i64 15391712275433856905, ; 572: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 201
	i64 15495723588366671405, ; 573: FFImageLoading.Compat.Svg.dll => 0xd70bde80f63c9e2d => 176
	i64 15526743539506359484, ; 574: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 135
	i64 15527772828719725935, ; 575: System.Console => 0xd77dbb1e38cd3d6f => 20
	i64 15530465045505749832, ; 576: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 65
	i64 15536481058354060254, ; 577: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 312
	i64 15541854775306130054, ; 578: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 125
	i64 15557562860424774966, ; 579: System.Net.Sockets => 0xd7e790fe7a6dc536 => 75
	i64 15582737692548360875, ; 580: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 269
	i64 15609085926864131306, ; 581: System.dll => 0xd89e9cf3334914ea => 164
	i64 15661133872274321916, ; 582: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 156
	i64 15664356999916475676, ; 583: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 312
	i64 15710114879900314733, ; 584: Microsoft.Win32.Registry => 0xda058a3f5d096c6d => 5
	i64 15743187114543869802, ; 585: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 320
	i64 15755368083429170162, ; 586: System.IO.FileSystem.Primitives => 0xdaa64fcbde529bf2 => 49
	i64 15777549416145007739, ; 587: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 283
	i64 15783653065526199428, ; 588: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 313
	i64 15817206913877585035, ; 589: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 144
	i64 15847085070278954535, ; 590: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 139
	i64 15885744048853936810, ; 591: System.Resources.Writer => 0xdc75800bd0b6eaaa => 100
	i64 15928521404965645318, ; 592: Microsoft.Maui.Controls.Compatibility => 0xdd0d79d32c2eec06 => 208
	i64 15934062614519587357, ; 593: System.Security.Cryptography.OpenSsl => 0xdd2129868f45a21d => 123
	i64 15937190497610202713, ; 594: System.Security.Cryptography.Cng => 0xdd2c465197c97e59 => 120
	i64 15963349826457351533, ; 595: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 142
	i64 15971679995444160383, ; 596: System.Formats.Tar.dll => 0xdda6ce5592a9677f => 39
	i64 15987609494471769098, ; 597: Firebase.Storage => 0xdddf662115a6fc0a => 179
	i64 16018552496348375205, ; 598: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 68
	i64 16054465462676478687, ; 599: System.Globalization.Extensions => 0xdecceb47319bdadf => 41
	i64 16154507427712707110, ; 600: System => 0xe03056ea4e39aa26 => 164
	i64 16156430004425724367, ; 601: Microsoft.AspNetCore.Http.Connections.Client.dll => 0xe0372b7d144211cf => 189
	i64 16219561732052121626, ; 602: System.Net.Security => 0xe1177575db7c781a => 73
	i64 16288847719894691167, ; 603: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 326
	i64 16315482530584035869, ; 604: WindowsBase.dll => 0xe26c3ceb1e8d821d => 165
	i64 16321164108206115771, ; 605: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 204
	i64 16324796876805858114, ; 606: SkiaSharp.dll => 0xe28d5444586b6342 => 216
	i64 16337011941688632206, ; 607: System.Security.Principal.Windows.dll => 0xe2b8b9cdc3aa638e => 127
	i64 16343918515847859304, ; 608: Microsoft.Extensions.Features.dll => 0xe2d1434bdf0a8c68 => 202
	i64 16361933716545543812, ; 609: Xamarin.AndroidX.ExifInterface.dll => 0xe3114406a52f1e84 => 255
	i64 16423015068819898779, ; 610: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 304
	i64 16454459195343277943, ; 611: System.Net.NetworkInformation => 0xe459fb756d988f77 => 68
	i64 16496768397145114574, ; 612: Mono.Android.Export.dll => 0xe4f04b741db987ce => 169
	i64 16589693266713801121, ; 613: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xe63a6e214f2a71a1 => 268
	i64 16605226748660468415, ; 614: Microsoft.AspNetCore.SignalR.Common => 0xe6719dbfe8b8cabf => 193
	i64 16621146507174665210, ; 615: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 242
	i64 16649148416072044166, ; 616: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 213
	i64 16677317093839702854, ; 617: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 275
	i64 16702652415771857902, ; 618: System.ValueTuple => 0xe7cbbde0b0e6d3ee => 151
	i64 16709499819875633724, ; 619: System.IO.Compression.ZipFile => 0xe7e4118e32240a3c => 45
	i64 16737807731308835127, ; 620: System.Runtime.Intrinsics => 0xe848a3736f733137 => 108
	i64 16758309481308491337, ; 621: System.IO.FileSystem.DriveInfo => 0xe89179af15740e49 => 48
	i64 16762783179241323229, ; 622: System.Reflection.TypeExtensions => 0xe8a15e7d0d927add => 96
	i64 16765015072123548030, ; 623: System.Diagnostics.TextWriterTraceListener.dll => 0xe8a94c621bfe717e => 31
	i64 16822611501064131242, ; 624: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 23
	i64 16833383113903931215, ; 625: mscorlib => 0xe99c30c1484d7f4f => 166
	i64 16856067890322379635, ; 626: System.Data.Common.dll => 0xe9ecc87060889373 => 22
	i64 16890310621557459193, ; 627: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 138
	i64 16933958494752847024, ; 628: System.Net.WebProxy.dll => 0xeb018187f0f3b4b0 => 78
	i64 16942731696432749159, ; 629: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 333
	i64 16977952268158210142, ; 630: System.IO.Pipes.AccessControl => 0xeb9dcda2851b905e => 54
	i64 16989020923549080504, ; 631: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xebc52084add25bb8 => 268
	i64 16998075588627545693, ; 632: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 273
	i64 17008137082415910100, ; 633: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 10
	i64 17024911836938395553, ; 634: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 231
	i64 17031351772568316411, ; 635: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 272
	i64 17037200463775726619, ; 636: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 259
	i64 17062143951396181894, ; 637: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 16
	i64 17089008752050867324, ; 638: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 340
	i64 17118171214553292978, ; 639: System.Threading.Channels => 0xed8ff6060fc420b2 => 139
	i64 17187273293601214786, ; 640: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 13
	i64 17201328579425343169, ; 641: System.ComponentModel.EventBasedAsync => 0xeeb76534d96c16c1 => 15
	i64 17202182880784296190, ; 642: System.Security.Cryptography.Encoding.dll => 0xeeba6e30627428fe => 122
	i64 17230721278011714856, ; 643: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 87
	i64 17234219099804750107, ; 644: System.Transactions.Local.dll => 0xef2c3ef5e11d511b => 149
	i64 17260702271250283638, ; 645: System.Data.Common => 0xef8a5543bba6bc76 => 22
	i64 17333249706306540043, ; 646: System.Diagnostics.Tracing.dll => 0xf08c12c5bb8b920b => 34
	i64 17338386382517543202, ; 647: System.Net.WebSockets.Client.dll => 0xf09e528d5c6da122 => 79
	i64 17342750010158924305, ; 648: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 318
	i64 17360349973592121190, ; 649: Xamarin.Google.Crypto.Tink.Android => 0xf0ec5a52686b9f66 => 297
	i64 17438153253682247751, ; 650: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 333
	i64 17470386307322966175, ; 651: System.Threading.Timer => 0xf27347c8d0d5709f => 147
	i64 17509662556995089465, ; 652: System.Net.WebSockets.dll => 0xf2fed1534ea67439 => 80
	i64 17514990004910432069, ; 653: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 316
	i64 17522591619082469157, ; 654: GoogleGson => 0xf32cc03d27a5bf25 => 185
	i64 17571845317586269034, ; 655: Microsoft.AspNetCore.Connections.Abstractions.dll => 0xf3dbbc377ad7336a => 188
	i64 17590473451926037903, ; 656: Xamarin.Android.Glide => 0xf41dea67fcfda58f => 224
	i64 17623389608345532001, ; 657: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 328
	i64 17627500474728259406, ; 658: System.Globalization => 0xf4a176498a351f4e => 42
	i64 17636563193350668017, ; 659: Microsoft.AspNetCore.Http.Connections.Common => 0xf4c1a8c826653ef1 => 190
	i64 17685921127322830888, ; 660: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 26
	i64 17702523067201099846, ; 661: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 339
	i64 17704177640604968747, ; 662: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 270
	i64 17710060891934109755, ; 663: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 267
	i64 17712670374920797664, ; 664: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 107
	i64 17743407583038752114, ; 665: System.CodeDom.dll => 0xf63d3f302bff4572 => 221
	i64 17777860260071588075, ; 666: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 110
	i64 17838668724098252521, ; 667: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 7
	i64 17887052286848052308, ; 668: CommunyStoreFrontEnd.dll => 0xf83b9349046aac54 => 0
	i64 17891337867145587222, ; 669: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 300
	i64 17928294245072900555, ; 670: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 44
	i64 17992315986609351877, ; 671: System.Xml.XmlDocument.dll => 0xf9b18c0ffc6eacc5 => 161
	i64 18025913125965088385, ; 672: System.Threading => 0xfa28e87b91334681 => 148
	i64 18099568558057551825, ; 673: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 327
	i64 18116111925905154859, ; 674: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 236
	i64 18121036031235206392, ; 675: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 272
	i64 18146411883821974900, ; 676: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 38
	i64 18146811631844267958, ; 677: System.ComponentModel.EventBasedAsync.dll => 0xfbd66d08820117b6 => 15
	i64 18225059387460068507, ; 678: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 146
	i64 18245806341561545090, ; 679: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 8
	i64 18260797123374478311, ; 680: Xamarin.AndroidX.Emoji2 => 0xfd6b623bde35f3e7 => 253
	i64 18305135509493619199, ; 681: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 274
	i64 18318849532986632368, ; 682: System.Security.dll => 0xfe39a097c37fa8b0 => 130
	i64 18324163916253801303, ; 683: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 322
	i64 18380184030268848184, ; 684: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 290
	i64 18439108438687598470 ; 685: System.Reflection.Metadata.dll => 0xffe4df6e2ee1c786 => 94
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [686 x i32] [
	i32 252, ; 0
	i32 173, ; 1
	i32 207, ; 2
	i32 171, ; 3
	i32 212, ; 4
	i32 220, ; 5
	i32 58, ; 6
	i32 239, ; 7
	i32 151, ; 8
	i32 280, ; 9
	i32 283, ; 10
	i32 246, ; 11
	i32 132, ; 12
	i32 218, ; 13
	i32 56, ; 14
	i32 282, ; 15
	i32 223, ; 16
	i32 315, ; 17
	i32 95, ; 18
	i32 265, ; 19
	i32 129, ; 20
	i32 145, ; 21
	i32 240, ; 22
	i32 18, ; 23
	i32 318, ; 24
	i32 251, ; 25
	i32 266, ; 26
	i32 307, ; 27
	i32 150, ; 28
	i32 104, ; 29
	i32 95, ; 30
	i32 295, ; 31
	i32 326, ; 32
	i32 197, ; 33
	i32 36, ; 34
	i32 28, ; 35
	i32 235, ; 36
	i32 273, ; 37
	i32 50, ; 38
	i32 115, ; 39
	i32 70, ; 40
	i32 209, ; 41
	i32 65, ; 42
	i32 170, ; 43
	i32 145, ; 44
	i32 324, ; 45
	i32 294, ; 46
	i32 234, ; 47
	i32 269, ; 48
	i32 259, ; 49
	i32 40, ; 50
	i32 89, ; 51
	i32 81, ; 52
	i32 214, ; 53
	i32 66, ; 54
	i32 62, ; 55
	i32 86, ; 56
	i32 233, ; 57
	i32 106, ; 58
	i32 314, ; 59
	i32 280, ; 60
	i32 102, ; 61
	i32 35, ; 62
	i32 230, ; 63
	i32 336, ; 64
	i32 282, ; 65
	i32 210, ; 66
	i32 336, ; 67
	i32 119, ; 68
	i32 267, ; 69
	i32 310, ; 70
	i32 328, ; 71
	i32 174, ; 72
	i32 142, ; 73
	i32 141, ; 74
	i32 303, ; 75
	i32 53, ; 76
	i32 35, ; 77
	i32 141, ; 78
	i32 214, ; 79
	i32 187, ; 80
	i32 175, ; 81
	i32 227, ; 82
	i32 237, ; 83
	i32 217, ; 84
	i32 205, ; 85
	i32 251, ; 86
	i32 8, ; 87
	i32 14, ; 88
	i32 332, ; 89
	i32 279, ; 90
	i32 51, ; 91
	i32 262, ; 92
	i32 136, ; 93
	i32 101, ; 94
	i32 244, ; 95
	i32 289, ; 96
	i32 116, ; 97
	i32 228, ; 98
	i32 163, ; 99
	i32 335, ; 100
	i32 166, ; 101
	i32 67, ; 102
	i32 200, ; 103
	i32 310, ; 104
	i32 80, ; 105
	i32 177, ; 106
	i32 101, ; 107
	i32 284, ; 108
	i32 183, ; 109
	i32 117, ; 110
	i32 315, ; 111
	i32 296, ; 112
	i32 78, ; 113
	i32 295, ; 114
	i32 114, ; 115
	i32 121, ; 116
	i32 48, ; 117
	i32 184, ; 118
	i32 128, ; 119
	i32 260, ; 120
	i32 231, ; 121
	i32 82, ; 122
	i32 178, ; 123
	i32 110, ; 124
	i32 75, ; 125
	i32 306, ; 126
	i32 212, ; 127
	i32 53, ; 128
	i32 217, ; 129
	i32 286, ; 130
	i32 198, ; 131
	i32 69, ; 132
	i32 285, ; 133
	i32 83, ; 134
	i32 172, ; 135
	i32 330, ; 136
	i32 116, ; 137
	i32 199, ; 138
	i32 156, ; 139
	i32 198, ; 140
	i32 220, ; 141
	i32 225, ; 142
	i32 167, ; 143
	i32 278, ; 144
	i32 252, ; 145
	i32 193, ; 146
	i32 203, ; 147
	i32 32, ; 148
	i32 210, ; 149
	i32 122, ; 150
	i32 72, ; 151
	i32 62, ; 152
	i32 161, ; 153
	i32 113, ; 154
	i32 182, ; 155
	i32 88, ; 156
	i32 208, ; 157
	i32 341, ; 158
	i32 105, ; 159
	i32 18, ; 160
	i32 146, ; 161
	i32 118, ; 162
	i32 58, ; 163
	i32 246, ; 164
	i32 17, ; 165
	i32 52, ; 166
	i32 92, ; 167
	i32 338, ; 168
	i32 55, ; 169
	i32 129, ; 170
	i32 152, ; 171
	i32 41, ; 172
	i32 92, ; 173
	i32 290, ; 174
	i32 50, ; 175
	i32 308, ; 176
	i32 162, ; 177
	i32 13, ; 178
	i32 264, ; 179
	i32 228, ; 180
	i32 285, ; 181
	i32 36, ; 182
	i32 67, ; 183
	i32 109, ; 184
	i32 229, ; 185
	i32 99, ; 186
	i32 99, ; 187
	i32 11, ; 188
	i32 11, ; 189
	i32 271, ; 190
	i32 25, ; 191
	i32 128, ; 192
	i32 76, ; 193
	i32 263, ; 194
	i32 109, ; 195
	i32 219, ; 196
	i32 289, ; 197
	i32 287, ; 198
	i32 106, ; 199
	i32 2, ; 200
	i32 26, ; 201
	i32 242, ; 202
	i32 157, ; 203
	i32 334, ; 204
	i32 21, ; 205
	i32 337, ; 206
	i32 49, ; 207
	i32 43, ; 208
	i32 126, ; 209
	i32 232, ; 210
	i32 59, ; 211
	i32 119, ; 212
	i32 183, ; 213
	i32 292, ; 214
	i32 255, ; 215
	i32 241, ; 216
	i32 3, ; 217
	i32 178, ; 218
	i32 261, ; 219
	i32 196, ; 220
	i32 281, ; 221
	i32 38, ; 222
	i32 124, ; 223
	i32 190, ; 224
	i32 191, ; 225
	i32 331, ; 226
	i32 281, ; 227
	i32 196, ; 228
	i32 331, ; 229
	i32 137, ; 230
	i32 149, ; 231
	i32 85, ; 232
	i32 90, ; 233
	i32 265, ; 234
	i32 215, ; 235
	i32 342, ; 236
	i32 215, ; 237
	i32 262, ; 238
	i32 319, ; 239
	i32 237, ; 240
	i32 248, ; 241
	i32 293, ; 242
	i32 206, ; 243
	i32 195, ; 244
	i32 298, ; 245
	i32 263, ; 246
	i32 133, ; 247
	i32 216, ; 248
	i32 96, ; 249
	i32 3, ; 250
	i32 327, ; 251
	i32 105, ; 252
	i32 330, ; 253
	i32 188, ; 254
	i32 33, ; 255
	i32 154, ; 256
	i32 158, ; 257
	i32 155, ; 258
	i32 82, ; 259
	i32 175, ; 260
	i32 223, ; 261
	i32 257, ; 262
	i32 194, ; 263
	i32 143, ; 264
	i32 87, ; 265
	i32 19, ; 266
	i32 258, ; 267
	i32 51, ; 268
	i32 227, ; 269
	i32 334, ; 270
	i32 61, ; 271
	i32 54, ; 272
	i32 4, ; 273
	i32 97, ; 274
	i32 226, ; 275
	i32 17, ; 276
	i32 155, ; 277
	i32 84, ; 278
	i32 307, ; 279
	i32 187, ; 280
	i32 29, ; 281
	i32 45, ; 282
	i32 180, ; 283
	i32 64, ; 284
	i32 66, ; 285
	i32 325, ; 286
	i32 172, ; 287
	i32 266, ; 288
	i32 1, ; 289
	i32 301, ; 290
	i32 47, ; 291
	i32 24, ; 292
	i32 234, ; 293
	i32 165, ; 294
	i32 108, ; 295
	i32 12, ; 296
	i32 260, ; 297
	i32 63, ; 298
	i32 27, ; 299
	i32 23, ; 300
	i32 93, ; 301
	i32 168, ; 302
	i32 12, ; 303
	i32 305, ; 304
	i32 179, ; 305
	i32 194, ; 306
	i32 213, ; 307
	i32 29, ; 308
	i32 103, ; 309
	i32 14, ; 310
	i32 126, ; 311
	i32 243, ; 312
	i32 275, ; 313
	i32 91, ; 314
	i32 264, ; 315
	i32 0, ; 316
	i32 9, ; 317
	i32 86, ; 318
	i32 254, ; 319
	i32 287, ; 320
	i32 329, ; 321
	i32 71, ; 322
	i32 168, ; 323
	i32 1, ; 324
	i32 274, ; 325
	i32 5, ; 326
	i32 329, ; 327
	i32 44, ; 328
	i32 27, ; 329
	i32 173, ; 330
	i32 302, ; 331
	i32 158, ; 332
	i32 277, ; 333
	i32 112, ; 334
	i32 339, ; 335
	i32 121, ; 336
	i32 218, ; 337
	i32 292, ; 338
	i32 233, ; 339
	i32 159, ; 340
	i32 131, ; 341
	i32 297, ; 342
	i32 57, ; 343
	i32 138, ; 344
	i32 83, ; 345
	i32 30, ; 346
	i32 244, ; 347
	i32 10, ; 348
	i32 294, ; 349
	i32 171, ; 350
	i32 241, ; 351
	i32 150, ; 352
	i32 94, ; 353
	i32 254, ; 354
	i32 60, ; 355
	i32 211, ; 356
	i32 221, ; 357
	i32 157, ; 358
	i32 314, ; 359
	i32 205, ; 360
	i32 64, ; 361
	i32 88, ; 362
	i32 79, ; 363
	i32 47, ; 364
	i32 209, ; 365
	i32 143, ; 366
	i32 311, ; 367
	i32 303, ; 368
	i32 202, ; 369
	i32 248, ; 370
	i32 74, ; 371
	i32 91, ; 372
	i32 300, ; 373
	i32 135, ; 374
	i32 90, ; 375
	i32 286, ; 376
	i32 306, ; 377
	i32 245, ; 378
	i32 309, ; 379
	i32 112, ; 380
	i32 42, ; 381
	i32 159, ; 382
	i32 4, ; 383
	i32 103, ; 384
	i32 70, ; 385
	i32 174, ; 386
	i32 60, ; 387
	i32 39, ; 388
	i32 235, ; 389
	i32 153, ; 390
	i32 56, ; 391
	i32 34, ; 392
	i32 204, ; 393
	i32 211, ; 394
	i32 232, ; 395
	i32 21, ; 396
	i32 163, ; 397
	i32 298, ; 398
	i32 320, ; 399
	i32 296, ; 400
	i32 291, ; 401
	i32 140, ; 402
	i32 219, ; 403
	i32 323, ; 404
	i32 206, ; 405
	i32 89, ; 406
	i32 147, ; 407
	i32 247, ; 408
	i32 162, ; 409
	i32 276, ; 410
	i32 6, ; 411
	i32 169, ; 412
	i32 31, ; 413
	i32 107, ; 414
	i32 257, ; 415
	i32 222, ; 416
	i32 321, ; 417
	i32 291, ; 418
	i32 203, ; 419
	i32 230, ; 420
	i32 284, ; 421
	i32 167, ; 422
	i32 258, ; 423
	i32 140, ; 424
	i32 317, ; 425
	i32 59, ; 426
	i32 144, ; 427
	i32 184, ; 428
	i32 81, ; 429
	i32 74, ; 430
	i32 130, ; 431
	i32 25, ; 432
	i32 7, ; 433
	i32 93, ; 434
	i32 288, ; 435
	i32 137, ; 436
	i32 224, ; 437
	i32 113, ; 438
	i32 9, ; 439
	i32 222, ; 440
	i32 104, ; 441
	i32 19, ; 442
	i32 181, ; 443
	i32 256, ; 444
	i32 270, ; 445
	i32 342, ; 446
	i32 250, ; 447
	i32 180, ; 448
	i32 33, ; 449
	i32 238, ; 450
	i32 46, ; 451
	i32 322, ; 452
	i32 30, ; 453
	i32 239, ; 454
	i32 57, ; 455
	i32 134, ; 456
	i32 114, ; 457
	i32 293, ; 458
	i32 335, ; 459
	i32 304, ; 460
	i32 55, ; 461
	i32 207, ; 462
	i32 6, ; 463
	i32 77, ; 464
	i32 177, ; 465
	i32 181, ; 466
	i32 249, ; 467
	i32 176, ; 468
	i32 111, ; 469
	i32 186, ; 470
	i32 253, ; 471
	i32 102, ; 472
	i32 309, ; 473
	i32 323, ; 474
	i32 189, ; 475
	i32 170, ; 476
	i32 115, ; 477
	i32 317, ; 478
	i32 288, ; 479
	i32 243, ; 480
	i32 192, ; 481
	i32 76, ; 482
	i32 299, ; 483
	i32 85, ; 484
	i32 301, ; 485
	i32 337, ; 486
	i32 236, ; 487
	i32 195, ; 488
	i32 338, ; 489
	i32 321, ; 490
	i32 278, ; 491
	i32 160, ; 492
	i32 2, ; 493
	i32 249, ; 494
	i32 24, ; 495
	i32 229, ; 496
	i32 32, ; 497
	i32 117, ; 498
	i32 37, ; 499
	i32 16, ; 500
	i32 316, ; 501
	i32 52, ; 502
	i32 182, ; 503
	i32 319, ; 504
	i32 302, ; 505
	i32 20, ; 506
	i32 123, ; 507
	i32 154, ; 508
	i32 256, ; 509
	i32 131, ; 510
	i32 311, ; 511
	i32 238, ; 512
	i32 148, ; 513
	i32 225, ; 514
	i32 120, ; 515
	i32 28, ; 516
	i32 132, ; 517
	i32 100, ; 518
	i32 134, ; 519
	i32 276, ; 520
	i32 153, ; 521
	i32 97, ; 522
	i32 125, ; 523
	i32 226, ; 524
	i32 197, ; 525
	i32 69, ; 526
	i32 72, ; 527
	i32 332, ; 528
	i32 261, ; 529
	i32 279, ; 530
	i32 313, ; 531
	i32 136, ; 532
	i32 124, ; 533
	i32 71, ; 534
	i32 191, ; 535
	i32 111, ; 536
	i32 271, ; 537
	i32 200, ; 538
	i32 152, ; 539
	i32 324, ; 540
	i32 340, ; 541
	i32 299, ; 542
	i32 192, ; 543
	i32 118, ; 544
	i32 247, ; 545
	i32 185, ; 546
	i32 341, ; 547
	i32 308, ; 548
	i32 127, ; 549
	i32 186, ; 550
	i32 133, ; 551
	i32 201, ; 552
	i32 77, ; 553
	i32 46, ; 554
	i32 250, ; 555
	i32 73, ; 556
	i32 63, ; 557
	i32 98, ; 558
	i32 84, ; 559
	i32 325, ; 560
	i32 43, ; 561
	i32 61, ; 562
	i32 277, ; 563
	i32 199, ; 564
	i32 37, ; 565
	i32 40, ; 566
	i32 240, ; 567
	i32 305, ; 568
	i32 160, ; 569
	i32 98, ; 570
	i32 245, ; 571
	i32 201, ; 572
	i32 176, ; 573
	i32 135, ; 574
	i32 20, ; 575
	i32 65, ; 576
	i32 312, ; 577
	i32 125, ; 578
	i32 75, ; 579
	i32 269, ; 580
	i32 164, ; 581
	i32 156, ; 582
	i32 312, ; 583
	i32 5, ; 584
	i32 320, ; 585
	i32 49, ; 586
	i32 283, ; 587
	i32 313, ; 588
	i32 144, ; 589
	i32 139, ; 590
	i32 100, ; 591
	i32 208, ; 592
	i32 123, ; 593
	i32 120, ; 594
	i32 142, ; 595
	i32 39, ; 596
	i32 179, ; 597
	i32 68, ; 598
	i32 41, ; 599
	i32 164, ; 600
	i32 189, ; 601
	i32 73, ; 602
	i32 326, ; 603
	i32 165, ; 604
	i32 204, ; 605
	i32 216, ; 606
	i32 127, ; 607
	i32 202, ; 608
	i32 255, ; 609
	i32 304, ; 610
	i32 68, ; 611
	i32 169, ; 612
	i32 268, ; 613
	i32 193, ; 614
	i32 242, ; 615
	i32 213, ; 616
	i32 275, ; 617
	i32 151, ; 618
	i32 45, ; 619
	i32 108, ; 620
	i32 48, ; 621
	i32 96, ; 622
	i32 31, ; 623
	i32 23, ; 624
	i32 166, ; 625
	i32 22, ; 626
	i32 138, ; 627
	i32 78, ; 628
	i32 333, ; 629
	i32 54, ; 630
	i32 268, ; 631
	i32 273, ; 632
	i32 10, ; 633
	i32 231, ; 634
	i32 272, ; 635
	i32 259, ; 636
	i32 16, ; 637
	i32 340, ; 638
	i32 139, ; 639
	i32 13, ; 640
	i32 15, ; 641
	i32 122, ; 642
	i32 87, ; 643
	i32 149, ; 644
	i32 22, ; 645
	i32 34, ; 646
	i32 79, ; 647
	i32 318, ; 648
	i32 297, ; 649
	i32 333, ; 650
	i32 147, ; 651
	i32 80, ; 652
	i32 316, ; 653
	i32 185, ; 654
	i32 188, ; 655
	i32 224, ; 656
	i32 328, ; 657
	i32 42, ; 658
	i32 190, ; 659
	i32 26, ; 660
	i32 339, ; 661
	i32 270, ; 662
	i32 267, ; 663
	i32 107, ; 664
	i32 221, ; 665
	i32 110, ; 666
	i32 7, ; 667
	i32 0, ; 668
	i32 300, ; 669
	i32 44, ; 670
	i32 161, ; 671
	i32 148, ; 672
	i32 327, ; 673
	i32 236, ; 674
	i32 272, ; 675
	i32 38, ; 676
	i32 15, ; 677
	i32 146, ; 678
	i32 8, ; 679
	i32 253, ; 680
	i32 274, ; 681
	i32 130, ; 682
	i32 322, ; 683
	i32 290, ; 684
	i32 94 ; 685
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
