; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [170 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [340 x i64] [
	i64 40218994123153105, ; 0: ExCSS.dll => 0x8ee2f649ef1ed1 => 35
	i64 98382396393917666, ; 1: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 54
	i64 120698629574877762, ; 2: Mono.Android => 0x1accec39cafe242 => 169
	i64 131669012237370309, ; 3: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 58
	i64 184471870596806994, ; 4: Svg.Skia => 0x28f60305df97952 => 66
	i64 196720943101637631, ; 5: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 119
	i64 210515253464952879, ; 6: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 73
	i64 232391251801502327, ; 7: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 90
	i64 404665707914610830, ; 8: Svg.Custom => 0x59da9513d08488e => 64
	i64 502670939551102150, ; 9: System.Management.dll => 0x6f9d88e66daf4c6 => 68
	i64 545109961164950392, ; 10: fi/Microsoft.Maui.Controls.resources.dll => 0x7909e9f1ec38b78 => 7
	i64 560278790331054453, ; 11: System.Reflection.Primitives => 0x7c6829760de3975 => 139
	i64 750875890346172408, ; 12: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 157
	i64 799765834175365804, ; 13: System.ComponentModel.dll => 0xb1956c9f18442ac => 106
	i64 849051935479314978, ; 14: hi/Microsoft.Maui.Controls.resources.dll => 0xbc8703ca21a3a22 => 10
	i64 872800313462103108, ; 15: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 78
	i64 901995307004200655, ; 16: Plugin.FilePicker.dll => 0xc8487f3e70e06cf => 97
	i64 1010599046655515943, ; 17: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 139
	i64 1120440138749646132, ; 18: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 94
	i64 1121665720830085036, ; 19: nb/Microsoft.Maui.Controls.resources.dll => 0xf90f507becf47ac => 18
	i64 1268860745194512059, ; 20: System.Drawing.dll => 0x119be62002c19ebb => 114
	i64 1369545283391376210, ; 21: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 86
	i64 1476839205573959279, ; 22: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 126
	i64 1486715745332614827, ; 23: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 55
	i64 1492954217099365037, ; 24: System.Net.HttpListener => 0x14b809f350210aad => 123
	i64 1513467482682125403, ; 25: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 168
	i64 1537168428375924959, ; 26: System.Threading.Thread.dll => 0x15551e8a954ae0df => 157
	i64 1556147632182429976, ; 27: ko/Microsoft.Maui.Controls.resources.dll => 0x15988c06d24c8918 => 16
	i64 1624659445732251991, ; 28: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 71
	i64 1628611045998245443, ; 29: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 83
	i64 1731380447121279447, ; 30: Newtonsoft.Json => 0x18071957e9b889d7 => 60
	i64 1743969030606105336, ; 31: System.Memory.dll => 0x1833d297e88f2af8 => 121
	i64 1767386781656293639, ; 32: System.Private.Uri.dll => 0x188704e9f5582107 => 134
	i64 1795316252682057001, ; 33: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 70
	i64 1825687700144851180, ; 34: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 140
	i64 1835311033149317475, ; 35: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 36: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 90
	i64 1875417405349196092, ; 37: System.Drawing.Primitives => 0x1a06d2319b6c713c => 113
	i64 1881198190668717030, ; 38: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1920760634179481754, ; 39: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 56
	i64 1959996714666907089, ; 40: tr/Microsoft.Maui.Controls.resources.dll => 0x1b334ea0a2a755d1 => 28
	i64 1972385128188460614, ; 41: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 148
	i64 1981742497975770890, ; 42: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 82
	i64 1983698669889758782, ; 43: cs/Microsoft.Maui.Controls.resources.dll => 0x1b87836e2031a63e => 2
	i64 2019660174692588140, ; 44: pl/Microsoft.Maui.Controls.resources.dll => 0x1c07463a6f8e1a6c => 20
	i64 2038176078398990831, ; 45: FFImageLoading.Compat => 0x1c490e5836aba9ef => 36
	i64 2102659300918482391, ; 46: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 113
	i64 2133195048986300728, ; 47: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 60
	i64 2136727539037051651, ; 48: FFImageLoading.Compat.Maui => 0x1da72e603a191b03 => 37
	i64 2188974421706709258, ; 49: SkiaSharp.HarfBuzz.dll => 0x1e60cca38c3e990a => 63
	i64 2262844636196693701, ; 50: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 78
	i64 2287834202362508563, ; 51: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 100
	i64 2302323944321350744, ; 52: ru/Microsoft.Maui.Controls.resources.dll => 0x1ff37f6ddb267c58 => 24
	i64 2329709569556905518, ; 53: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 81
	i64 2335503487726329082, ; 54: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 153
	i64 2470498323731680442, ; 55: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 74
	i64 2497223385847772520, ; 56: System.Runtime => 0x22a7eb7046413568 => 146
	i64 2547086958574651984, ; 57: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 69
	i64 2602673633151553063, ; 58: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2624866290265602282, ; 59: mscorlib.dll => 0x246d65fbde2db8ea => 164
	i64 2632269733008246987, ; 60: System.Net.NameResolution => 0x2487b36034f808cb => 124
	i64 2656907746661064104, ; 61: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 49
	i64 2662981627730767622, ; 62: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2721478136117819115, ; 63: FFImageLoading.Compat.Svg.Maui.dll => 0x25c4a1f21f4b76eb => 39
	i64 2812926542227278819, ; 64: Google.Apis.Core.dll => 0x270985c960b98be3 => 44
	i64 2895129759130297543, ; 65: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017704767998173186, ; 66: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 94
	i64 3149515290929572490, ; 67: Google.Apis.Drive.v3 => 0x2bb553786284aa8a => 45
	i64 3289520064315143713, ; 68: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 80
	i64 3311221304742556517, ; 69: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 132
	i64 3324483813344587579, ; 70: FFImageLoading.Compat.Transformations => 0x2e22f06a13f0af3b => 40
	i64 3325875462027654285, ; 71: System.Runtime.Numerics => 0x2e27e21c8958b48d => 143
	i64 3328853167529574890, ; 72: System.Net.Sockets.dll => 0x2e327651a008c1ea => 130
	i64 3344514922410554693, ; 73: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 96
	i64 3429672777697402584, ; 74: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 58
	i64 3461602852075779363, ; 75: SkiaSharp.HarfBuzz => 0x300a15741f74b523 => 63
	i64 3494946837667399002, ; 76: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 47
	i64 3522470458906976663, ; 77: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 91
	i64 3551103847008531295, ; 78: System.Private.CoreLib.dll => 0x31480e226177735f => 166
	i64 3567343442040498961, ; 79: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 80: System.Runtime.dll => 0x319037675df7e556 => 146
	i64 3638003163729360188, ; 81: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 48
	i64 3647754201059316852, ; 82: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 161
	i64 3655542548057982301, ; 83: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 47
	i64 3658489898830683555, ; 84: Svg.Skia.dll => 0x32c5912df2285da3 => 66
	i64 3716579019761409177, ; 85: netstandard.dll => 0x3393f0ed5c8c5c99 => 165
	i64 3727469159507183293, ; 86: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 89
	i64 3869221888984012293, ; 87: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 51
	i64 3890352374528606784, ; 88: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 56
	i64 3933965368022646939, ; 89: System.Net.Requests => 0x369840a8bfadc09b => 127
	i64 3966267475168208030, ; 90: System.Memory => 0x370b03412596249e => 121
	i64 4009997192427317104, ; 91: System.Runtime.Serialization.Primitives => 0x37a65f335cf1a770 => 145
	i64 4056584864658557221, ; 92: Google.Apis.Auth => 0x384be27113330925 => 43
	i64 4073500526318903918, ; 93: System.Private.Xml.dll => 0x3887fb25779ae26e => 136
	i64 4120493066591692148, ; 94: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4154383907710350974, ; 95: System.ComponentModel => 0x39a7562737acb67e => 106
	i64 4167269041631776580, ; 96: System.Threading.ThreadPool => 0x39d51d1d3df1cf44 => 158
	i64 4168469861834746866, ; 97: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 147
	i64 4187479170553454871, ; 98: System.Linq.Expressions => 0x3a1cea1e912fa117 => 119
	i64 4205801962323029395, ; 99: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 105
	i64 4356591372459378815, ; 100: vi/Microsoft.Maui.Controls.resources.dll => 0x3c75b8c562f9087f => 30
	i64 4373617458794931033, ; 101: System.IO.Pipes.dll => 0x3cb235e806eb2359 => 118
	i64 4679594760078841447, ; 102: ar/Microsoft.Maui.Controls.resources.dll => 0x40f142a407475667 => 0
	i64 4794310189461587505, ; 103: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 69
	i64 4795410492532947900, ; 104: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 91
	i64 4809057822547766521, ; 105: System.Drawing => 0x42bd349c3145ecf9 => 114
	i64 4814660307502931973, ; 106: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 124
	i64 4853321196694829351, ; 107: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 142
	i64 5103417709280584325, ; 108: System.Collections.Specialized => 0x46d2fb5e161b6285 => 102
	i64 5182934613077526976, ; 109: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 102
	i64 5290786973231294105, ; 110: System.Runtime.Loader => 0x496ca6b869b72699 => 142
	i64 5306356071055648198, ; 111: Svg.Model.dll => 0x49a3f6bb7b0265c6 => 65
	i64 5423376490970181369, ; 112: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 140
	i64 5471532531798518949, ; 113: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5507995362134886206, ; 114: System.Core.dll => 0x4c705499688c873e => 108
	i64 5522859530602327440, ; 115: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 116: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 116
	i64 5573260873512690141, ; 117: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 151
	i64 5650097808083101034, ; 118: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 148
	i64 5665389054145784248, ; 119: Google.Apis.Core => 0x4e9f815406bee9b8 => 44
	i64 5692067934154308417, ; 120: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 93
	i64 5817425494286445158, ; 121: FFImageLoading.Compat.Transformations.dll => 0x50bba5aa3e3eaa66 => 40
	i64 5979151488806146654, ; 122: System.Formats.Asn1 => 0x52fa3699a489d25e => 115
	i64 5984759512290286505, ; 123: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 149
	i64 6068057819846744445, ; 124: ro/Microsoft.Maui.Controls.resources.dll => 0x5436126fec7f197d => 23
	i64 6200764641006662125, ; 125: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6222399776351216807, ; 126: System.Text.Json.dll => 0x565a67a0ffe264a7 => 154
	i64 6284145129771520194, ; 127: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 137
	i64 6354612700029906737, ; 128: ShimSkiaSharp.dll => 0x58301e951e77ef31 => 61
	i64 6357457916754632952, ; 129: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 34
	i64 6363787360044722189, ; 130: ShimSkiaSharp => 0x5850b6e31d96280d => 61
	i64 6401687960814735282, ; 131: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 81
	i64 6478287442656530074, ; 132: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6548213210057960872, ; 133: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 77
	i64 6560151584539558821, ; 134: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 53
	i64 6671798237668743565, ; 135: SkiaSharp => 0x5c96fd260152998d => 62
	i64 6743165466166707109, ; 136: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6777482997383978746, ; 137: pt/Microsoft.Maui.Controls.resources.dll => 0x5e0e74e0a2525efa => 22
	i64 6786606130239981554, ; 138: System.Diagnostics.TraceSource => 0x5e2ede51877147f2 => 112
	i64 6814185388980153342, ; 139: System.Xml.XDocument.dll => 0x5e90d98217d1abfe => 162
	i64 6876862101832370452, ; 140: System.Xml.Linq => 0x5f6f85a57d108914 => 160
	i64 6894844156784520562, ; 141: System.Numerics.Vectors => 0x5faf683aead1ad72 => 132
	i64 6956410392315992198, ; 142: FFImageLoading.Compat.Maui.dll => 0x608a226529d49886 => 37
	i64 6987056692196838363, ; 143: System.Management => 0x60f7030ae3e88bdb => 68
	i64 7083547580668757502, ; 144: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 135
	i64 7220009545223068405, ; 145: sv/Microsoft.Maui.Controls.resources.dll => 0x6432a06d99f35af5 => 26
	i64 7270811800166795866, ; 146: System.Linq => 0x64e71ccf51a90a5a => 120
	i64 7377312882064240630, ; 147: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 105
	i64 7488575175965059935, ; 148: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 160
	i64 7489048572193775167, ; 149: System.ObjectModel => 0x67ee71ff6b419e3f => 133
	i64 7509866036550816153, ; 150: Plugin.FilePicker => 0x6838675f0b61d199 => 97
	i64 7592577537120840276, ; 151: System.Diagnostics.Process => 0x695e410af5b2aa54 => 111
	i64 7640829051849446879, ; 152: Fizzler => 0x6a09ad8a30f895df => 41
	i64 7654504624184590948, ; 153: System.Net.Http => 0x6a3a4366801b8264 => 122
	i64 7708790323521193081, ; 154: ms/Microsoft.Maui.Controls.resources.dll => 0x6afb1ff4d1730479 => 17
	i64 7714652370974252055, ; 155: System.Private.CoreLib => 0x6b0ff375198b9c17 => 166
	i64 7735176074855944702, ; 156: Microsoft.CSharp => 0x6b58dda848e391fe => 99
	i64 7735352534559001595, ; 157: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 95
	i64 7836164640616011524, ; 158: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 71
	i64 8064050204834738623, ; 159: System.Collections.dll => 0x6fe942efa61731bf => 103
	i64 8083354569033831015, ; 160: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 80
	i64 8087206902342787202, ; 161: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 110
	i64 8167236081217502503, ; 162: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 167
	i64 8185542183669246576, ; 163: System.Collections => 0x7198e33f4794aa70 => 103
	i64 8246048515196606205, ; 164: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 59
	i64 8264926008854159966, ; 165: System.Diagnostics.Process.dll => 0x72b2ea6a64a3a25e => 111
	i64 8368701292315763008, ; 166: System.Security.Cryptography => 0x7423997c6fd56140 => 151
	i64 8400357532724379117, ; 167: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 88
	i64 8410671156615598628, ; 168: System.Reflection.Emit.Lightweight.dll => 0x74b8b4daf4b25224 => 138
	i64 8471458099622282839, ; 169: CommunyStoreFrontEnd => 0x7590aa4205978657 => 98
	i64 8563666267364444763, ; 170: System.Private.Uri => 0x76d841191140ca5b => 134
	i64 8614108721271900878, ; 171: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x778b763e14018ace => 21
	i64 8626175481042262068, ; 172: Java.Interop => 0x77b654e585b55834 => 167
	i64 8638972117149407195, ; 173: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 99
	i64 8639588376636138208, ; 174: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 87
	i64 8677882282824630478, ; 175: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8725526185868997716, ; 176: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 110
	i64 8834232125107082525, ; 177: ExCSS => 0x7a997f4fe05a151d => 35
	i64 8941376889969657626, ; 178: System.Xml.XDocument => 0x7c1626e87187471a => 162
	i64 9045785047181495996, ; 179: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9248940107580716988, ; 180: Svg.Custom.dll => 0x805ad6065d3637bc => 64
	i64 9312692141327339315, ; 181: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 93
	i64 9324707631942237306, ; 182: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 70
	i64 9659729154652888475, ; 183: System.Text.RegularExpressions => 0x860e407c9991dd9b => 155
	i64 9678050649315576968, ; 184: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 74
	i64 9702891218465930390, ; 185: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 101
	i64 9808709177481450983, ; 186: Mono.Android.dll => 0x881f890734e555e7 => 169
	i64 9956195530459977388, ; 187: Microsoft.Maui => 0x8a2b8315b36616ac => 57
	i64 9959489431142554298, ; 188: System.CodeDom => 0x8a3736deb7825aba => 67
	i64 9991543690424095600, ; 189: es/Microsoft.Maui.Controls.resources.dll => 0x8aa9180c89861370 => 6
	i64 10038780035334861115, ; 190: System.Net.Http.dll => 0x8b50e941206af13b => 122
	i64 10051358222726253779, ; 191: System.Private.Xml => 0x8b7d990c97ccccd3 => 136
	i64 10092835686693276772, ; 192: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 55
	i64 10143853363526200146, ; 193: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10229024438826829339, ; 194: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 77
	i64 10236703004850800690, ; 195: System.Net.ServicePoint.dll => 0x8e101325834e4832 => 129
	i64 10245369515835430794, ; 196: System.Reflection.Emit.Lightweight => 0x8e2edd4ad7fc978a => 138
	i64 10364469296367737616, ; 197: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 137
	i64 10406448008575299332, ; 198: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 96
	i64 10430153318873392755, ; 199: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 75
	i64 10506226065143327199, ; 200: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10785150219063592792, ; 201: System.Net.Primitives => 0x95ac8cfb68830758 => 126
	i64 10794455402127920989, ; 202: FFImageLoading.Compat.dll => 0x95cd9bff2ba18f5d => 36
	i64 11002576679268595294, ; 203: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 52
	i64 11009005086950030778, ; 204: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 57
	i64 11023048688141570732, ; 205: System.Core => 0x98f9bc61168392ac => 108
	i64 11103970607964515343, ; 206: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11162124722117608902, ; 207: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 92
	i64 11216600183782743182, ; 208: Svg.Model => 0x9ba95e7065f39c8e => 65
	i64 11220793807500858938, ; 209: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 210: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 53
	i64 11340910727871153756, ; 211: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 76
	i64 11485890710487134646, ; 212: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 141
	i64 11518296021396496455, ; 213: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 214: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 92
	i64 11530571088791430846, ; 215: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 51
	i64 11597940890313164233, ; 216: netstandard => 0xa0f429ca8d1805c9 => 165
	i64 11705530742807338875, ; 217: he/Microsoft.Maui.Controls.resources.dll => 0xa272663128721f7b => 9
	i64 11967721421130449846, ; 218: Google.Apis.Drive.v3.dll => 0xa615e3398d5043b6 => 45
	i64 12040886584167504988, ; 219: System.Net.ServicePoint => 0xa719d28d8e121c5c => 129
	i64 12145679461940342714, ; 220: System.Text.Json => 0xa88e1f1ebcb62fba => 154
	i64 12201331334810686224, ; 221: System.Runtime.Serialization.Primitives.dll => 0xa953d6341e3bd310 => 145
	i64 12437742355241350664, ; 222: Google.Apis.dll => 0xac9bbcc62bfdb608 => 42
	i64 12451044538927396471, ; 223: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 79
	i64 12466513435562512481, ; 224: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 84
	i64 12475113361194491050, ; 225: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 34
	i64 12499978561737021417, ; 226: Fizzler.dll => 0xad78d846305557e9 => 41
	i64 12517810545449516888, ; 227: System.Diagnostics.TraceSource.dll => 0xadb8325e6f283f58 => 112
	i64 12538491095302438457, ; 228: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 72
	i64 12550732019250633519, ; 229: System.IO.Compression => 0xae2d28465e8e1b2f => 117
	i64 12681088699309157496, ; 230: it/Microsoft.Maui.Controls.resources.dll => 0xaffc46fc178aec78 => 14
	i64 12700543734426720211, ; 231: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 73
	i64 12708922737231849740, ; 232: System.Text.Encoding.Extensions => 0xb05f29e50e96e90c => 152
	i64 12823819093633476069, ; 233: th/Microsoft.Maui.Controls.resources.dll => 0xb1f75b85abe525e5 => 27
	i64 12835242264250840079, ; 234: System.IO.Pipes => 0xb21ff0d5d6c0740f => 118
	i64 12843321153144804894, ; 235: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 54
	i64 12859557719246324186, ; 236: System.Net.WebHeaderCollection.dll => 0xb276539ce04f41da => 131
	i64 12942564684163400157, ; 237: FFImageLoading.Compat.Svg.Maui => 0xb39d3a01f21341dd => 39
	i64 12958614573187252691, ; 238: Google.Apis => 0xb3d63f4bf006c1d3 => 42
	i64 13034532390708954583, ; 239: FFImageLoading.Compat.Svg => 0xb4e3f6264187c5d7 => 38
	i64 13068258254871114833, ; 240: System.Runtime.Serialization.Formatters.dll => 0xb55bc7a4eaa8b451 => 144
	i64 13106026140046202731, ; 241: HarfBuzzSharp.dll => 0xb5e1f555ee70176b => 46
	i64 13221551921002590604, ; 242: ca/Microsoft.Maui.Controls.resources.dll => 0xb77c636bdebe318c => 1
	i64 13222659110913276082, ; 243: ja/Microsoft.Maui.Controls.resources.dll => 0xb78052679c1178b2 => 15
	i64 13343850469010654401, ; 244: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 168
	i64 13381594904270902445, ; 245: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13465488254036897740, ; 246: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 95
	i64 13467053111158216594, ; 247: uk/Microsoft.Maui.Controls.resources.dll => 0xbae49573fde79792 => 29
	i64 13540124433173649601, ; 248: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13545416393490209236, ; 249: id/Microsoft.Maui.Controls.resources.dll => 0xbbfafc7174bc99d4 => 13
	i64 13572454107664307259, ; 250: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 89
	i64 13717397318615465333, ; 251: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 104
	i64 13755568601956062840, ; 252: fr/Microsoft.Maui.Controls.resources.dll => 0xbee598c36b1b9678 => 8
	i64 13782512541859110153, ; 253: Google.Apis.Auth.dll => 0xbf45522249e0dd09 => 43
	i64 13814445057219246765, ; 254: hr/Microsoft.Maui.Controls.resources.dll => 0xbfb6c49664b43aad => 11
	i64 13881769479078963060, ; 255: System.Console.dll => 0xc0a5f3cade5c6774 => 107
	i64 13959074834287824816, ; 256: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 79
	i64 14100563506285742564, ; 257: da/Microsoft.Maui.Controls.resources.dll => 0xc3af43cd0cff89e4 => 3
	i64 14124974489674258913, ; 258: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 72
	i64 14125464355221830302, ; 259: System.Threading.dll => 0xc407bafdbc707a9e => 159
	i64 14254574811015963973, ; 260: System.Text.Encoding.Extensions.dll => 0xc5d26c4442d66545 => 152
	i64 14327709162229390963, ; 261: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 150
	i64 14461014870687870182, ; 262: System.Net.Requests.dll => 0xc8afd8683afdece6 => 127
	i64 14464374589798375073, ; 263: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14522721392235705434, ; 264: el/Microsoft.Maui.Controls.resources.dll => 0xc98b12295c2cf45a => 5
	i64 14551742072151931844, ; 265: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 153
	i64 14561513370130550166, ; 266: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 149
	i64 14622043554576106986, ; 267: System.Runtime.Serialization.Formatters => 0xcaebef2458cc85ea => 144
	i64 14669215534098758659, ; 268: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 49
	i64 14705122255218365489, ; 269: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14744092281598614090, ; 270: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14832630590065248058, ; 271: System.Security.Claims => 0xcdd816ef5d6e873a => 147
	i64 14852515768018889994, ; 272: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 76
	i64 14892012299694389861, ; 273: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xceab0e490a083a65 => 33
	i64 14904040806490515477, ; 274: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14931407803744742450, ; 275: HarfBuzzSharp => 0xcf3704499ab36c32 => 46
	i64 14954917835170835695, ; 276: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 50
	i64 14984936317414011727, ; 277: System.Net.WebHeaderCollection => 0xcff5302fe54ff34f => 131
	i64 14987728460634540364, ; 278: System.IO.Compression.dll => 0xcfff1ba06622494c => 117
	i64 15015154896917945444, ; 279: System.Net.Security.dll => 0xd0608bd33642dc64 => 128
	i64 15076659072870671916, ; 280: System.ObjectModel.dll => 0xd13b0d8c1620662c => 133
	i64 15111608613780139878, ; 281: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 282: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 116
	i64 15133485256822086103, ; 283: System.Linq.dll => 0xd204f0a9127dd9d7 => 120
	i64 15227001540531775957, ; 284: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 48
	i64 15370334346939861994, ; 285: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 75
	i64 15391712275433856905, ; 286: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 50
	i64 15495723588366671405, ; 287: FFImageLoading.Compat.Svg.dll => 0xd70bde80f63c9e2d => 38
	i64 15527772828719725935, ; 288: System.Console => 0xd77dbb1e38cd3d6f => 107
	i64 15530465045505749832, ; 289: System.Net.HttpListener.dll => 0xd7874bacc9fdb348 => 123
	i64 15536481058354060254, ; 290: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15541854775306130054, ; 291: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 150
	i64 15557562860424774966, ; 292: System.Net.Sockets => 0xd7e790fe7a6dc536 => 130
	i64 15582737692548360875, ; 293: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 83
	i64 15609085926864131306, ; 294: System.dll => 0xd89e9cf3334914ea => 163
	i64 15661133872274321916, ; 295: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 161
	i64 15664356999916475676, ; 296: de/Microsoft.Maui.Controls.resources.dll => 0xd962f9b2b6ecd51c => 4
	i64 15743187114543869802, ; 297: hu/Microsoft.Maui.Controls.resources.dll => 0xda7b09450ae4ef6a => 12
	i64 15783653065526199428, ; 298: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 15847085070278954535, ; 299: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 156
	i64 16018552496348375205, ; 300: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 125
	i64 16154507427712707110, ; 301: System => 0xe03056ea4e39aa26 => 163
	i64 16219561732052121626, ; 302: System.Net.Security => 0xe1177575db7c781a => 128
	i64 16288847719894691167, ; 303: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 304: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 52
	i64 16324796876805858114, ; 305: SkiaSharp.dll => 0xe28d5444586b6342 => 62
	i64 16454459195343277943, ; 306: System.Net.NetworkInformation => 0xe459fb756d988f77 => 125
	i64 16649148416072044166, ; 307: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 59
	i64 16677317093839702854, ; 308: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 88
	i64 16833383113903931215, ; 309: mscorlib => 0xe99c30c1484d7f4f => 164
	i64 16856067890322379635, ; 310: System.Data.Common.dll => 0xe9ecc87060889373 => 109
	i64 16890310621557459193, ; 311: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 155
	i64 16942731696432749159, ; 312: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16998075588627545693, ; 313: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 86
	i64 17008137082415910100, ; 314: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 101
	i64 17031351772568316411, ; 315: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 85
	i64 17062143951396181894, ; 316: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 104
	i64 17089008752050867324, ; 317: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xed285aeb25888c7c => 32
	i64 17118171214553292978, ; 318: System.Threading.Channels => 0xed8ff6060fc420b2 => 156
	i64 17230721278011714856, ; 319: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 135
	i64 17260702271250283638, ; 320: System.Data.Common => 0xef8a5543bba6bc76 => 109
	i64 17342750010158924305, ; 321: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17438153253682247751, ; 322: sk/Microsoft.Maui.Controls.resources.dll => 0xf200c3fe308d7847 => 25
	i64 17514990004910432069, ; 323: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17623389608345532001, ; 324: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17702523067201099846, ; 325: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xf5abfef008ae1846 => 31
	i64 17704177640604968747, ; 326: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 84
	i64 17710060891934109755, ; 327: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 82
	i64 17712670374920797664, ; 328: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 141
	i64 17743407583038752114, ; 329: System.CodeDom.dll => 0xf63d3f302bff4572 => 67
	i64 17777860260071588075, ; 330: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 143
	i64 17887052286848052308, ; 331: CommunyStoreFrontEnd.dll => 0xf83b9349046aac54 => 98
	i64 18025913125965088385, ; 332: System.Threading => 0xfa28e87b91334681 => 159
	i64 18099568558057551825, ; 333: nl/Microsoft.Maui.Controls.resources.dll => 0xfb2e95b53ad977d1 => 19
	i64 18121036031235206392, ; 334: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 85
	i64 18146411883821974900, ; 335: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 115
	i64 18225059387460068507, ; 336: System.Threading.ThreadPool.dll => 0xfcec6af3cff4a49b => 158
	i64 18245806341561545090, ; 337: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 100
	i64 18305135509493619199, ; 338: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 87
	i64 18324163916253801303 ; 339: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [340 x i32] [
	i32 35, ; 0
	i32 54, ; 1
	i32 169, ; 2
	i32 58, ; 3
	i32 66, ; 4
	i32 119, ; 5
	i32 73, ; 6
	i32 90, ; 7
	i32 64, ; 8
	i32 68, ; 9
	i32 7, ; 10
	i32 139, ; 11
	i32 157, ; 12
	i32 106, ; 13
	i32 10, ; 14
	i32 78, ; 15
	i32 97, ; 16
	i32 139, ; 17
	i32 94, ; 18
	i32 18, ; 19
	i32 114, ; 20
	i32 86, ; 21
	i32 126, ; 22
	i32 55, ; 23
	i32 123, ; 24
	i32 168, ; 25
	i32 157, ; 26
	i32 16, ; 27
	i32 71, ; 28
	i32 83, ; 29
	i32 60, ; 30
	i32 121, ; 31
	i32 134, ; 32
	i32 70, ; 33
	i32 140, ; 34
	i32 6, ; 35
	i32 90, ; 36
	i32 113, ; 37
	i32 28, ; 38
	i32 56, ; 39
	i32 28, ; 40
	i32 148, ; 41
	i32 82, ; 42
	i32 2, ; 43
	i32 20, ; 44
	i32 36, ; 45
	i32 113, ; 46
	i32 60, ; 47
	i32 37, ; 48
	i32 63, ; 49
	i32 78, ; 50
	i32 100, ; 51
	i32 24, ; 52
	i32 81, ; 53
	i32 153, ; 54
	i32 74, ; 55
	i32 146, ; 56
	i32 69, ; 57
	i32 27, ; 58
	i32 164, ; 59
	i32 124, ; 60
	i32 49, ; 61
	i32 2, ; 62
	i32 39, ; 63
	i32 44, ; 64
	i32 7, ; 65
	i32 94, ; 66
	i32 45, ; 67
	i32 80, ; 68
	i32 132, ; 69
	i32 40, ; 70
	i32 143, ; 71
	i32 130, ; 72
	i32 96, ; 73
	i32 58, ; 74
	i32 63, ; 75
	i32 47, ; 76
	i32 91, ; 77
	i32 166, ; 78
	i32 22, ; 79
	i32 146, ; 80
	i32 48, ; 81
	i32 161, ; 82
	i32 47, ; 83
	i32 66, ; 84
	i32 165, ; 85
	i32 89, ; 86
	i32 51, ; 87
	i32 56, ; 88
	i32 127, ; 89
	i32 121, ; 90
	i32 145, ; 91
	i32 43, ; 92
	i32 136, ; 93
	i32 33, ; 94
	i32 106, ; 95
	i32 158, ; 96
	i32 147, ; 97
	i32 119, ; 98
	i32 105, ; 99
	i32 30, ; 100
	i32 118, ; 101
	i32 0, ; 102
	i32 69, ; 103
	i32 91, ; 104
	i32 114, ; 105
	i32 124, ; 106
	i32 142, ; 107
	i32 102, ; 108
	i32 102, ; 109
	i32 142, ; 110
	i32 65, ; 111
	i32 140, ; 112
	i32 26, ; 113
	i32 108, ; 114
	i32 29, ; 115
	i32 116, ; 116
	i32 151, ; 117
	i32 148, ; 118
	i32 44, ; 119
	i32 93, ; 120
	i32 40, ; 121
	i32 115, ; 122
	i32 149, ; 123
	i32 23, ; 124
	i32 23, ; 125
	i32 154, ; 126
	i32 137, ; 127
	i32 61, ; 128
	i32 34, ; 129
	i32 61, ; 130
	i32 81, ; 131
	i32 11, ; 132
	i32 77, ; 133
	i32 53, ; 134
	i32 62, ; 135
	i32 19, ; 136
	i32 22, ; 137
	i32 112, ; 138
	i32 162, ; 139
	i32 160, ; 140
	i32 132, ; 141
	i32 37, ; 142
	i32 68, ; 143
	i32 135, ; 144
	i32 26, ; 145
	i32 120, ; 146
	i32 105, ; 147
	i32 160, ; 148
	i32 133, ; 149
	i32 97, ; 150
	i32 111, ; 151
	i32 41, ; 152
	i32 122, ; 153
	i32 17, ; 154
	i32 166, ; 155
	i32 99, ; 156
	i32 95, ; 157
	i32 71, ; 158
	i32 103, ; 159
	i32 80, ; 160
	i32 110, ; 161
	i32 167, ; 162
	i32 103, ; 163
	i32 59, ; 164
	i32 111, ; 165
	i32 151, ; 166
	i32 88, ; 167
	i32 138, ; 168
	i32 98, ; 169
	i32 134, ; 170
	i32 21, ; 171
	i32 167, ; 172
	i32 99, ; 173
	i32 87, ; 174
	i32 21, ; 175
	i32 110, ; 176
	i32 35, ; 177
	i32 162, ; 178
	i32 31, ; 179
	i32 64, ; 180
	i32 93, ; 181
	i32 70, ; 182
	i32 155, ; 183
	i32 74, ; 184
	i32 101, ; 185
	i32 169, ; 186
	i32 57, ; 187
	i32 67, ; 188
	i32 6, ; 189
	i32 122, ; 190
	i32 136, ; 191
	i32 55, ; 192
	i32 3, ; 193
	i32 77, ; 194
	i32 129, ; 195
	i32 138, ; 196
	i32 137, ; 197
	i32 96, ; 198
	i32 75, ; 199
	i32 1, ; 200
	i32 126, ; 201
	i32 36, ; 202
	i32 52, ; 203
	i32 57, ; 204
	i32 108, ; 205
	i32 12, ; 206
	i32 92, ; 207
	i32 65, ; 208
	i32 15, ; 209
	i32 53, ; 210
	i32 76, ; 211
	i32 141, ; 212
	i32 13, ; 213
	i32 92, ; 214
	i32 51, ; 215
	i32 165, ; 216
	i32 9, ; 217
	i32 45, ; 218
	i32 129, ; 219
	i32 154, ; 220
	i32 145, ; 221
	i32 42, ; 222
	i32 79, ; 223
	i32 84, ; 224
	i32 34, ; 225
	i32 41, ; 226
	i32 112, ; 227
	i32 72, ; 228
	i32 117, ; 229
	i32 14, ; 230
	i32 73, ; 231
	i32 152, ; 232
	i32 27, ; 233
	i32 118, ; 234
	i32 54, ; 235
	i32 131, ; 236
	i32 39, ; 237
	i32 42, ; 238
	i32 38, ; 239
	i32 144, ; 240
	i32 46, ; 241
	i32 1, ; 242
	i32 15, ; 243
	i32 168, ; 244
	i32 9, ; 245
	i32 95, ; 246
	i32 29, ; 247
	i32 30, ; 248
	i32 13, ; 249
	i32 89, ; 250
	i32 104, ; 251
	i32 8, ; 252
	i32 43, ; 253
	i32 11, ; 254
	i32 107, ; 255
	i32 79, ; 256
	i32 3, ; 257
	i32 72, ; 258
	i32 159, ; 259
	i32 152, ; 260
	i32 150, ; 261
	i32 127, ; 262
	i32 24, ; 263
	i32 5, ; 264
	i32 153, ; 265
	i32 149, ; 266
	i32 144, ; 267
	i32 49, ; 268
	i32 16, ; 269
	i32 32, ; 270
	i32 147, ; 271
	i32 76, ; 272
	i32 33, ; 273
	i32 0, ; 274
	i32 46, ; 275
	i32 50, ; 276
	i32 131, ; 277
	i32 117, ; 278
	i32 128, ; 279
	i32 133, ; 280
	i32 17, ; 281
	i32 116, ; 282
	i32 120, ; 283
	i32 48, ; 284
	i32 75, ; 285
	i32 50, ; 286
	i32 38, ; 287
	i32 107, ; 288
	i32 123, ; 289
	i32 4, ; 290
	i32 150, ; 291
	i32 130, ; 292
	i32 83, ; 293
	i32 163, ; 294
	i32 161, ; 295
	i32 4, ; 296
	i32 12, ; 297
	i32 5, ; 298
	i32 156, ; 299
	i32 125, ; 300
	i32 163, ; 301
	i32 128, ; 302
	i32 18, ; 303
	i32 52, ; 304
	i32 62, ; 305
	i32 125, ; 306
	i32 59, ; 307
	i32 88, ; 308
	i32 164, ; 309
	i32 109, ; 310
	i32 155, ; 311
	i32 25, ; 312
	i32 86, ; 313
	i32 101, ; 314
	i32 85, ; 315
	i32 104, ; 316
	i32 32, ; 317
	i32 156, ; 318
	i32 135, ; 319
	i32 109, ; 320
	i32 10, ; 321
	i32 25, ; 322
	i32 8, ; 323
	i32 20, ; 324
	i32 31, ; 325
	i32 84, ; 326
	i32 82, ; 327
	i32 141, ; 328
	i32 67, ; 329
	i32 143, ; 330
	i32 98, ; 331
	i32 159, ; 332
	i32 19, ; 333
	i32 85, ; 334
	i32 115, ; 335
	i32 158, ; 336
	i32 100, ; 337
	i32 87, ; 338
	i32 14 ; 339
], align 16

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
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
