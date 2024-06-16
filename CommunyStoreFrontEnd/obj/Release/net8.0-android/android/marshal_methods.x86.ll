; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [170 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [340 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 125
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 124
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 60
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 157
	i32 67008169, ; 4: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 68219467, ; 5: System.Security.Cryptography.Primitives => 0x410f24b => 149
	i32 72070932, ; 6: Microsoft.Maui.Graphics.dll => 0x44bb714 => 59
	i32 106842217, ; 7: FFImageLoading.Compat.Svg.dll => 0x65e4869 => 38
	i32 117431740, ; 8: System.Runtime.InteropServices => 0x6ffddbc => 141
	i32 122350210, ; 9: System.Threading.Channels.dll => 0x74aea82 => 156
	i32 142721839, ; 10: System.Net.WebHeaderCollection => 0x881c32f => 131
	i32 149764678, ; 11: Svg.Skia.dll => 0x8ed3a46 => 66
	i32 149972175, ; 12: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 149
	i32 165246403, ; 13: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 73
	i32 182336117, ; 14: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 91
	i32 195452805, ; 15: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 16: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 17: System.ComponentModel => 0xc38ff48 => 106
	i32 230752869, ; 18: Microsoft.CSharp.dll => 0xdc10265 => 99
	i32 246610117, ; 19: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 138
	i32 280992041, ; 20: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 303593359, ; 21: FFImageLoading.Compat.Svg.Maui => 0x1218778f => 39
	i32 317674968, ; 22: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 23: Xamarin.AndroidX.Activity.dll => 0x13031348 => 69
	i32 336156722, ; 24: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 25: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 80
	i32 356389973, ; 26: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 367780167, ; 27: System.IO.Pipes => 0x15ebe147 => 118
	i32 375677976, ; 28: System.Net.ServicePoint.dll => 0x16646418 => 129
	i32 379916513, ; 29: System.Threading.Thread.dll => 0x16a510e1 => 157
	i32 385762202, ; 30: System.Memory.dll => 0x16fe439a => 121
	i32 392610295, ; 31: System.Threading.ThreadPool.dll => 0x1766c1f7 => 158
	i32 395744057, ; 32: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 435591531, ; 33: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 34: System.Collections => 0x1a61054f => 103
	i32 450948140, ; 35: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 79
	i32 451504562, ; 36: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 150
	i32 459347974, ; 37: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 145
	i32 465658307, ; 38: ExCSS => 0x1bc161c3 => 35
	i32 465846621, ; 39: mscorlib => 0x1bc4415d => 164
	i32 469710990, ; 40: System.dll => 0x1bff388e => 163
	i32 469965489, ; 41: Svg.Model => 0x1c031ab1 => 65
	i32 498788369, ; 42: System.ObjectModel => 0x1dbae811 => 133
	i32 500358224, ; 43: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 44: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 45: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 54
	i32 525008092, ; 46: SkiaSharp.dll => 0x1f4afcdc => 62
	i32 539058512, ; 47: Microsoft.Extensions.Logging => 0x20216150 => 51
	i32 592146354, ; 48: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 613668793, ; 49: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 148
	i32 627609679, ; 50: Xamarin.AndroidX.CustomView => 0x2568904f => 77
	i32 627931235, ; 51: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 662205335, ; 52: System.Text.Encodings.Web.dll => 0x27787397 => 153
	i32 672442732, ; 53: System.Collections.Concurrent => 0x2814a96c => 100
	i32 683518922, ; 54: System.Net.Security => 0x28bdabca => 128
	i32 688181140, ; 55: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 690569205, ; 56: System.Xml.Linq.dll => 0x29293ff5 => 160
	i32 706645707, ; 57: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 58: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 59: System.Runtime.Loader.dll => 0x2b15ed29 => 142
	i32 759454413, ; 60: System.Net.Requests => 0x2d445acd => 127
	i32 762598435, ; 61: System.IO.Pipes.dll => 0x2d745423 => 118
	i32 775507847, ; 62: System.IO.Compression => 0x2e394f87 => 117
	i32 777317022, ; 63: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 778756650, ; 64: SkiaSharp.HarfBuzz.dll => 0x2e6ae22a => 63
	i32 789151979, ; 65: Microsoft.Extensions.Options => 0x2f0980eb => 53
	i32 804715423, ; 66: System.Data.Common => 0x2ff6fb9f => 109
	i32 823281589, ; 67: System.Private.Uri.dll => 0x311247b5 => 134
	i32 830298997, ; 68: System.IO.Compression.Brotli => 0x317d5b75 => 116
	i32 904024072, ; 69: System.ComponentModel.Primitives.dll => 0x35e25008 => 104
	i32 926902833, ; 70: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 955402788, ; 71: Newtonsoft.Json => 0x38f24a24 => 60
	i32 967690846, ; 72: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 80
	i32 975874589, ; 73: System.Xml.XDocument => 0x3a2aaa1d => 162
	i32 987950438, ; 74: FFImageLoading.Compat.Maui.dll => 0x3ae2ed66 => 37
	i32 992768348, ; 75: System.Collections.dll => 0x3b2c715c => 103
	i32 1012816738, ; 76: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 90
	i32 1019214401, ; 77: System.Drawing => 0x3cbffa41 => 114
	i32 1028951442, ; 78: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 50
	i32 1029334545, ; 79: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 80: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 70
	i32 1036536393, ; 81: System.Drawing.Primitives.dll => 0x3dc84a49 => 113
	i32 1044663988, ; 82: System.Linq.Expressions.dll => 0x3e444eb4 => 119
	i32 1052210849, ; 83: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 82
	i32 1082857460, ; 84: System.ComponentModel.TypeConverter => 0x408b17f4 => 105
	i32 1084122840, ; 85: Xamarin.Kotlin.StdLib => 0x409e66d8 => 95
	i32 1098259244, ; 86: System => 0x41761b2c => 163
	i32 1118262833, ; 87: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 88: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 89: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 87
	i32 1179022490, ; 90: Plugin.FilePicker => 0x4646749a => 97
	i32 1203215381, ; 91: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1208641965, ; 92: System.Diagnostics.Process => 0x480a69ad => 111
	i32 1234928153, ; 93: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1260983243, ; 94: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1271249867, ; 95: Plugin.FilePicker.dll => 0x4bc5bbcb => 97
	i32 1293217323, ; 96: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 78
	i32 1321685135, ; 97: FFImageLoading.Compat.Svg.Maui.dll => 0x4ec7508f => 39
	i32 1324164729, ; 98: System.Linq => 0x4eed2679 => 120
	i32 1373134921, ; 99: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 100: Xamarin.AndroidX.SavedState => 0x52114ed3 => 90
	i32 1406073936, ; 101: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 74
	i32 1408764838, ; 102: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 144
	i32 1430672901, ; 103: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1452070440, ; 104: System.Formats.Asn1.dll => 0x568cd628 => 115
	i32 1458022317, ; 105: System.Net.Security.dll => 0x56e7a7ad => 128
	i32 1461004990, ; 106: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 107: System.IO.Compression.dll => 0x57261233 => 117
	i32 1469204771, ; 108: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 71
	i32 1470490898, ; 109: Microsoft.Extensions.Primitives => 0x57a5e912 => 54
	i32 1480492111, ; 110: System.IO.Compression.Brotli.dll => 0x583e844f => 116
	i32 1493001747, ; 111: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1514721132, ; 112: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1543031311, ; 113: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 155
	i32 1551623176, ; 114: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1600541741, ; 115: ShimSkiaSharp => 0x5f66542d => 61
	i32 1622152042, ; 116: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 84
	i32 1624863272, ; 117: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 93
	i32 1636350590, ; 118: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 76
	i32 1639515021, ; 119: System.Net.Http.dll => 0x61b9038d => 122
	i32 1639986890, ; 120: System.Text.RegularExpressions => 0x61c036ca => 155
	i32 1657153582, ; 121: System.Runtime => 0x62c6282e => 146
	i32 1658251792, ; 122: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 94
	i32 1675936053, ; 123: CommunyStoreFrontEnd => 0x63e4c135 => 98
	i32 1677501392, ; 124: System.Net.Primitives.dll => 0x63fca3d0 => 126
	i32 1679769178, ; 125: System.Security.Cryptography => 0x641f3e5a => 151
	i32 1729485958, ; 126: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 72
	i32 1736233607, ; 127: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1743415430, ; 128: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 129: System.Diagnostics.TraceSource.dll => 0x69239124 => 112
	i32 1766324549, ; 130: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 91
	i32 1770582343, ; 131: Microsoft.Extensions.Logging.dll => 0x6988f147 => 51
	i32 1776026572, ; 132: System.Core.dll => 0x69dc03cc => 108
	i32 1780572499, ; 133: Mono.Android.Runtime.dll => 0x6a216153 => 168
	i32 1782862114, ; 134: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 135: Xamarin.AndroidX.Fragment => 0x6a96652d => 79
	i32 1793755602, ; 136: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 137: Xamarin.AndroidX.Loader => 0x6bcd3296 => 84
	i32 1813058853, ; 138: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 95
	i32 1813201214, ; 139: Xamarin.Google.Android.Material => 0x6c13413e => 94
	i32 1818569960, ; 140: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 88
	i32 1824175904, ; 141: System.Text.Encoding.Extensions => 0x6cbab720 => 152
	i32 1824722060, ; 142: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 144
	i32 1828688058, ; 143: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 52
	i32 1832300034, ; 144: FFImageLoading.Compat => 0x6d36ae02 => 36
	i32 1842015223, ; 145: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1853025655, ; 146: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 147: System.Linq.Expressions => 0x6ec71a65 => 119
	i32 1870277092, ; 148: System.Reflection.Primitives => 0x6f7a29e4 => 139
	i32 1875935024, ; 149: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1910275211, ; 150: System.Collections.NonGeneric.dll => 0x71dc7c8b => 101
	i32 1927897671, ; 151: System.CodeDom.dll => 0x72e96247 => 67
	i32 1939592360, ; 152: System.Private.Xml.Linq => 0x739bd4a8 => 135
	i32 1968388702, ; 153: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 47
	i32 2003115576, ; 154: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 155: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 82
	i32 2025202353, ; 156: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2044812727, ; 157: FFImageLoading.Compat.dll => 0x79e15db7 => 36
	i32 2045470958, ; 158: System.Private.Xml => 0x79eb68ee => 136
	i32 2055257422, ; 159: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 81
	i32 2066184531, ; 160: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 161: System.Diagnostics.TraceSource => 0x7b6f419e => 112
	i32 2079903147, ; 162: System.Runtime.dll => 0x7bf8cdab => 146
	i32 2090596640, ; 163: System.Numerics.Vectors => 0x7c9bf920 => 132
	i32 2127167465, ; 164: System.Console => 0x7ec9ffe9 => 107
	i32 2142473426, ; 165: System.Collections.Specialized => 0x7fb38cd2 => 102
	i32 2159891885, ; 166: Microsoft.Maui => 0x80bd55ad => 57
	i32 2169148018, ; 167: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2178612968, ; 168: System.CodeDom => 0x81dafee8 => 67
	i32 2181898931, ; 169: Microsoft.Extensions.Options.dll => 0x820d22b3 => 53
	i32 2192057212, ; 170: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 52
	i32 2193016926, ; 171: System.ObjectModel.dll => 0x82b6c85e => 133
	i32 2201107256, ; 172: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 96
	i32 2201231467, ; 173: System.Net.Http => 0x8334206b => 122
	i32 2207618523, ; 174: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 175: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 48
	i32 2270573516, ; 176: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 177: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 89
	i32 2295906218, ; 178: System.Net.Sockets => 0x88d8bfaa => 130
	i32 2303942373, ; 179: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 180: System.Private.CoreLib.dll => 0x896b7878 => 166
	i32 2327893114, ; 181: ExCSS.dll => 0x8ac0d47a => 35
	i32 2340441535, ; 182: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 140
	i32 2353062107, ; 183: System.Net.Primitives => 0x8c40e0db => 126
	i32 2363070029, ; 184: Fizzler.dll => 0x8cd9964d => 41
	i32 2368005991, ; 185: System.Xml.ReaderWriter.dll => 0x8d24e767 => 161
	i32 2371007202, ; 186: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 47
	i32 2395872292, ; 187: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2414007524, ; 188: Google.Apis.Drive.v3.dll => 0x8fe2d4e4 => 45
	i32 2427813419, ; 189: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 190: System.Console.dll => 0x912896e5 => 107
	i32 2458678730, ; 191: System.Net.Sockets.dll => 0x928c75ca => 130
	i32 2471841756, ; 192: netstandard.dll => 0x93554fdc => 165
	i32 2475788418, ; 193: Java.Interop.dll => 0x93918882 => 167
	i32 2480646305, ; 194: Microsoft.Maui.Controls => 0x93dba8a1 => 55
	i32 2484371297, ; 195: System.Net.ServicePoint => 0x94147f61 => 129
	i32 2522808685, ; 196: FFImageLoading.Compat.Maui => 0x965f016d => 37
	i32 2523023297, ; 197: Svg.Custom.dll => 0x966247c1 => 64
	i32 2538310050, ; 198: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 138
	i32 2550873716, ; 199: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 200: Microsoft.CSharp => 0x98ba5a04 => 99
	i32 2570120770, ; 201: System.Text.Encodings.Web => 0x9930ee42 => 153
	i32 2585220780, ; 202: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 152
	i32 2589602615, ; 203: System.Threading.ThreadPool => 0x9a5a3337 => 158
	i32 2593496499, ; 204: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2602257211, ; 205: Svg.Model.dll => 0x9b1b4b3b => 65
	i32 2605712449, ; 206: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 96
	i32 2609324236, ; 207: Svg.Custom => 0x9b8720cc => 64
	i32 2617129537, ; 208: System.Private.Xml.dll => 0x9bfe3a41 => 136
	i32 2620871830, ; 209: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 76
	i32 2626831493, ; 210: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2653915012, ; 211: FFImageLoading.Compat.Transformations => 0x9e2f8784 => 40
	i32 2663698177, ; 212: System.Runtime.Loader => 0x9ec4cf01 => 142
	i32 2664396074, ; 213: System.Xml.XDocument.dll => 0x9ecf752a => 162
	i32 2665622720, ; 214: System.Drawing.Primitives => 0x9ee22cc0 => 113
	i32 2676780864, ; 215: System.Data.Common.dll => 0x9f8c6f40 => 109
	i32 2717744543, ; 216: System.Security.Claims => 0xa1fd7d9f => 147
	i32 2724373263, ; 217: System.Runtime.Numerics.dll => 0xa262a30f => 143
	i32 2732626843, ; 218: Xamarin.AndroidX.Activity => 0xa2e0939b => 69
	i32 2735172069, ; 219: System.Threading.Channels => 0xa30769e5 => 156
	i32 2737747696, ; 220: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 71
	i32 2752995522, ; 221: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 222: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 56
	i32 2764765095, ; 223: Microsoft.Maui.dll => 0xa4caf7a7 => 57
	i32 2778768386, ; 224: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 92
	i32 2785988530, ; 225: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 226: Microsoft.Maui.Graphics => 0xa7008e0b => 59
	i32 2806116107, ; 227: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 228: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 74
	i32 2831556043, ; 229: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 230: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 92
	i32 2861189240, ; 231: Microsoft.Maui.Essentials => 0xaa8a4878 => 58
	i32 2893550578, ; 232: Google.Apis.Core => 0xac7813f2 => 44
	i32 2898407901, ; 233: System.Management => 0xacc231dd => 68
	i32 2905242038, ; 234: mscorlib.dll => 0xad2a79b6 => 164
	i32 2909740682, ; 235: System.Private.CoreLib => 0xad6f1e8a => 166
	i32 2916838712, ; 236: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 93
	i32 2919462931, ; 237: System.Numerics.Vectors.dll => 0xae037813 => 132
	i32 2959614098, ; 238: System.ComponentModel.dll => 0xb0682092 => 106
	i32 2972252294, ; 239: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 148
	i32 2978675010, ; 240: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 78
	i32 2990604888, ; 241: Google.Apis => 0xb2410258 => 42
	i32 3038032645, ; 242: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 243: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 85
	i32 3059408633, ; 244: Mono.Android.Runtime => 0xb65adef9 => 168
	i32 3059793426, ; 245: System.ComponentModel.Primitives => 0xb660be12 => 104
	i32 3077302341, ; 246: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3090735792, ; 247: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 150
	i32 3099732863, ; 248: System.Security.Claims.dll => 0xb8c22b7f => 147
	i32 3103600923, ; 249: System.Formats.Asn1 => 0xb8fd311b => 115
	i32 3134694676, ; 250: ShimSkiaSharp.dll => 0xbad7a514 => 61
	i32 3159123045, ; 251: System.Reflection.Primitives.dll => 0xbc4c6465 => 139
	i32 3178803400, ; 252: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 86
	i32 3220365878, ; 253: System.Threading => 0xbff2e236 => 159
	i32 3258312781, ; 254: Xamarin.AndroidX.CardView => 0xc235e84d => 72
	i32 3293856089, ; 255: Google.Apis.Drive.v3 => 0xc4544159 => 45
	i32 3305363605, ; 256: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 257: System.Net.Requests.dll => 0xc5b097e4 => 127
	i32 3317135071, ; 258: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 77
	i32 3340387945, ; 259: SkiaSharp => 0xc71a4669 => 62
	i32 3346324047, ; 260: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 87
	i32 3357674450, ; 261: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 262: System.Text.Json => 0xc82afec1 => 154
	i32 3362522851, ; 263: Xamarin.AndroidX.Core => 0xc86c06e3 => 75
	i32 3366347497, ; 264: Java.Interop => 0xc8a662e9 => 167
	i32 3366730806, ; 265: FFImageLoading.Compat.Transformations.dll => 0xc8ac3c36 => 40
	i32 3374999561, ; 266: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 89
	i32 3381016424, ; 267: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 268: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 49
	i32 3430777524, ; 269: netstandard => 0xcc7d82b4 => 165
	i32 3453592554, ; 270: Google.Apis.Core.dll => 0xcdd9a3ea => 44
	i32 3459084094, ; 271: Fizzler => 0xce2d6f3e => 41
	i32 3463511458, ; 272: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 273: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 105
	i32 3476120550, ; 274: Mono.Android => 0xcf3163e6 => 169
	i32 3479583265, ; 275: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3484440000, ; 276: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485117614, ; 277: System.Text.Json.dll => 0xcfbaacae => 154
	i32 3509114376, ; 278: System.Xml.Linq => 0xd128d608 => 160
	i32 3539954161, ; 279: System.Net.HttpListener => 0xd2ff69f1 => 123
	i32 3580758918, ; 280: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3608519521, ; 281: System.Linq.dll => 0xd715a361 => 120
	i32 3612435020, ; 282: System.Management.dll => 0xd751624c => 68
	i32 3624195450, ; 283: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 140
	i32 3641597786, ; 284: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 81
	i32 3643446276, ; 285: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 286: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 86
	i32 3657292374, ; 287: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 48
	i32 3660523487, ; 288: System.Net.NetworkInformation => 0xda2f27df => 125
	i32 3672681054, ; 289: Mono.Android.dll => 0xdae8aa5e => 169
	i32 3697841164, ; 290: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3724971120, ; 291: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 85
	i32 3732100267, ; 292: System.Net.NameResolution => 0xde7354ab => 124
	i32 3748608112, ; 293: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 110
	i32 3786282454, ; 294: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 73
	i32 3792276235, ; 295: System.Collections.NonGeneric => 0xe2098b0b => 101
	i32 3792835768, ; 296: HarfBuzzSharp => 0xe21214b8 => 46
	i32 3793997468, ; 297: Google.Apis.Auth.dll => 0xe223ce9c => 43
	i32 3802395368, ; 298: System.Collections.Specialized.dll => 0xe2a3f2e8 => 102
	i32 3823082795, ; 299: System.Security.Cryptography.dll => 0xe3df9d2b => 151
	i32 3841636137, ; 300: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 50
	i32 3849253459, ; 301: System.Runtime.InteropServices.dll => 0xe56ef253 => 141
	i32 3870376305, ; 302: System.Net.HttpListener.dll => 0xe6b14171 => 123
	i32 3885497537, ; 303: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 131
	i32 3889960447, ; 304: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 305: System.Collections.Concurrent.dll => 0xe839deed => 100
	i32 3896760992, ; 306: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 75
	i32 3928044579, ; 307: System.Xml.ReaderWriter => 0xea213423 => 161
	i32 3931092270, ; 308: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 88
	i32 3953583589, ; 309: Svg.Skia => 0xeba6e5e5 => 66
	i32 3955647286, ; 310: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 70
	i32 3980434154, ; 311: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 312: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4003436829, ; 313: System.Diagnostics.Process.dll => 0xee9f991d => 111
	i32 4003906742, ; 314: HarfBuzzSharp.dll => 0xeea6c4b6 => 46
	i32 4025784931, ; 315: System.Memory => 0xeff49a63 => 121
	i32 4046471985, ; 316: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 56
	i32 4054681211, ; 317: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 137
	i32 4059682726, ; 318: Google.Apis.dll => 0xf1f9d7a6 => 42
	i32 4066802364, ; 319: SkiaSharp.HarfBuzz => 0xf2667abc => 63
	i32 4068434129, ; 320: System.Private.Xml.Linq.dll => 0xf27f60d1 => 135
	i32 4073602200, ; 321: System.Threading.dll => 0xf2ce3c98 => 159
	i32 4082882467, ; 322: Google.Apis.Auth => 0xf35bd7a3 => 43
	i32 4094352644, ; 323: Microsoft.Maui.Essentials.dll => 0xf40add04 => 58
	i32 4099507663, ; 324: System.Drawing.dll => 0xf45985cf => 114
	i32 4100113165, ; 325: System.Private.Uri => 0xf462c30d => 134
	i32 4102112229, ; 326: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4116961181, ; 327: CommunyStoreFrontEnd.dll => 0xf563d79d => 98
	i32 4125707920, ; 328: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 329: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 49
	i32 4147896353, ; 330: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 137
	i32 4150914736, ; 331: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4151237749, ; 332: System.Core => 0xf76edc75 => 108
	i32 4181436372, ; 333: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 145
	i32 4182413190, ; 334: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 83
	i32 4213026141, ; 335: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 110
	i32 4271975918, ; 336: Microsoft.Maui.Controls.dll => 0xfea12dee => 55
	i32 4273436745, ; 337: FFImageLoading.Compat.Svg => 0xfeb77849 => 38
	i32 4274976490, ; 338: System.Runtime.Numerics => 0xfecef6ea => 143
	i32 4292120959 ; 339: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 83
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [340 x i32] [
	i32 125, ; 0
	i32 124, ; 1
	i32 60, ; 2
	i32 157, ; 3
	i32 33, ; 4
	i32 149, ; 5
	i32 59, ; 6
	i32 38, ; 7
	i32 141, ; 8
	i32 156, ; 9
	i32 131, ; 10
	i32 66, ; 11
	i32 149, ; 12
	i32 73, ; 13
	i32 91, ; 14
	i32 30, ; 15
	i32 31, ; 16
	i32 106, ; 17
	i32 99, ; 18
	i32 138, ; 19
	i32 2, ; 20
	i32 39, ; 21
	i32 30, ; 22
	i32 69, ; 23
	i32 15, ; 24
	i32 80, ; 25
	i32 14, ; 26
	i32 118, ; 27
	i32 129, ; 28
	i32 157, ; 29
	i32 121, ; 30
	i32 158, ; 31
	i32 34, ; 32
	i32 26, ; 33
	i32 103, ; 34
	i32 79, ; 35
	i32 150, ; 36
	i32 145, ; 37
	i32 35, ; 38
	i32 164, ; 39
	i32 163, ; 40
	i32 65, ; 41
	i32 133, ; 42
	i32 13, ; 43
	i32 7, ; 44
	i32 54, ; 45
	i32 62, ; 46
	i32 51, ; 47
	i32 21, ; 48
	i32 148, ; 49
	i32 77, ; 50
	i32 19, ; 51
	i32 153, ; 52
	i32 100, ; 53
	i32 128, ; 54
	i32 1, ; 55
	i32 160, ; 56
	i32 16, ; 57
	i32 4, ; 58
	i32 142, ; 59
	i32 127, ; 60
	i32 118, ; 61
	i32 117, ; 62
	i32 25, ; 63
	i32 63, ; 64
	i32 53, ; 65
	i32 109, ; 66
	i32 134, ; 67
	i32 116, ; 68
	i32 104, ; 69
	i32 28, ; 70
	i32 60, ; 71
	i32 80, ; 72
	i32 162, ; 73
	i32 37, ; 74
	i32 103, ; 75
	i32 90, ; 76
	i32 114, ; 77
	i32 50, ; 78
	i32 3, ; 79
	i32 70, ; 80
	i32 113, ; 81
	i32 119, ; 82
	i32 82, ; 83
	i32 105, ; 84
	i32 95, ; 85
	i32 163, ; 86
	i32 16, ; 87
	i32 22, ; 88
	i32 87, ; 89
	i32 97, ; 90
	i32 20, ; 91
	i32 111, ; 92
	i32 18, ; 93
	i32 2, ; 94
	i32 97, ; 95
	i32 78, ; 96
	i32 39, ; 97
	i32 120, ; 98
	i32 32, ; 99
	i32 90, ; 100
	i32 74, ; 101
	i32 144, ; 102
	i32 0, ; 103
	i32 115, ; 104
	i32 128, ; 105
	i32 6, ; 106
	i32 117, ; 107
	i32 71, ; 108
	i32 54, ; 109
	i32 116, ; 110
	i32 10, ; 111
	i32 5, ; 112
	i32 155, ; 113
	i32 25, ; 114
	i32 61, ; 115
	i32 84, ; 116
	i32 93, ; 117
	i32 76, ; 118
	i32 122, ; 119
	i32 155, ; 120
	i32 146, ; 121
	i32 94, ; 122
	i32 98, ; 123
	i32 126, ; 124
	i32 151, ; 125
	i32 72, ; 126
	i32 23, ; 127
	i32 1, ; 128
	i32 112, ; 129
	i32 91, ; 130
	i32 51, ; 131
	i32 108, ; 132
	i32 168, ; 133
	i32 17, ; 134
	i32 79, ; 135
	i32 9, ; 136
	i32 84, ; 137
	i32 95, ; 138
	i32 94, ; 139
	i32 88, ; 140
	i32 152, ; 141
	i32 144, ; 142
	i32 52, ; 143
	i32 36, ; 144
	i32 29, ; 145
	i32 26, ; 146
	i32 119, ; 147
	i32 139, ; 148
	i32 8, ; 149
	i32 101, ; 150
	i32 67, ; 151
	i32 135, ; 152
	i32 47, ; 153
	i32 5, ; 154
	i32 82, ; 155
	i32 0, ; 156
	i32 36, ; 157
	i32 136, ; 158
	i32 81, ; 159
	i32 4, ; 160
	i32 112, ; 161
	i32 146, ; 162
	i32 132, ; 163
	i32 107, ; 164
	i32 102, ; 165
	i32 57, ; 166
	i32 12, ; 167
	i32 67, ; 168
	i32 53, ; 169
	i32 52, ; 170
	i32 133, ; 171
	i32 96, ; 172
	i32 122, ; 173
	i32 14, ; 174
	i32 48, ; 175
	i32 8, ; 176
	i32 89, ; 177
	i32 130, ; 178
	i32 18, ; 179
	i32 166, ; 180
	i32 35, ; 181
	i32 140, ; 182
	i32 126, ; 183
	i32 41, ; 184
	i32 161, ; 185
	i32 47, ; 186
	i32 13, ; 187
	i32 45, ; 188
	i32 10, ; 189
	i32 107, ; 190
	i32 130, ; 191
	i32 165, ; 192
	i32 167, ; 193
	i32 55, ; 194
	i32 129, ; 195
	i32 37, ; 196
	i32 64, ; 197
	i32 138, ; 198
	i32 11, ; 199
	i32 99, ; 200
	i32 153, ; 201
	i32 152, ; 202
	i32 158, ; 203
	i32 20, ; 204
	i32 65, ; 205
	i32 96, ; 206
	i32 64, ; 207
	i32 136, ; 208
	i32 76, ; 209
	i32 15, ; 210
	i32 40, ; 211
	i32 142, ; 212
	i32 162, ; 213
	i32 113, ; 214
	i32 109, ; 215
	i32 147, ; 216
	i32 143, ; 217
	i32 69, ; 218
	i32 156, ; 219
	i32 71, ; 220
	i32 21, ; 221
	i32 56, ; 222
	i32 57, ; 223
	i32 92, ; 224
	i32 27, ; 225
	i32 59, ; 226
	i32 6, ; 227
	i32 74, ; 228
	i32 19, ; 229
	i32 92, ; 230
	i32 58, ; 231
	i32 44, ; 232
	i32 68, ; 233
	i32 164, ; 234
	i32 166, ; 235
	i32 93, ; 236
	i32 132, ; 237
	i32 106, ; 238
	i32 148, ; 239
	i32 78, ; 240
	i32 42, ; 241
	i32 34, ; 242
	i32 85, ; 243
	i32 168, ; 244
	i32 104, ; 245
	i32 12, ; 246
	i32 150, ; 247
	i32 147, ; 248
	i32 115, ; 249
	i32 61, ; 250
	i32 139, ; 251
	i32 86, ; 252
	i32 159, ; 253
	i32 72, ; 254
	i32 45, ; 255
	i32 7, ; 256
	i32 127, ; 257
	i32 77, ; 258
	i32 62, ; 259
	i32 87, ; 260
	i32 24, ; 261
	i32 154, ; 262
	i32 75, ; 263
	i32 167, ; 264
	i32 40, ; 265
	i32 89, ; 266
	i32 3, ; 267
	i32 49, ; 268
	i32 165, ; 269
	i32 44, ; 270
	i32 41, ; 271
	i32 11, ; 272
	i32 105, ; 273
	i32 169, ; 274
	i32 24, ; 275
	i32 23, ; 276
	i32 154, ; 277
	i32 160, ; 278
	i32 123, ; 279
	i32 31, ; 280
	i32 120, ; 281
	i32 68, ; 282
	i32 140, ; 283
	i32 81, ; 284
	i32 28, ; 285
	i32 86, ; 286
	i32 48, ; 287
	i32 125, ; 288
	i32 169, ; 289
	i32 33, ; 290
	i32 85, ; 291
	i32 124, ; 292
	i32 110, ; 293
	i32 73, ; 294
	i32 101, ; 295
	i32 46, ; 296
	i32 43, ; 297
	i32 102, ; 298
	i32 151, ; 299
	i32 50, ; 300
	i32 141, ; 301
	i32 123, ; 302
	i32 131, ; 303
	i32 32, ; 304
	i32 100, ; 305
	i32 75, ; 306
	i32 161, ; 307
	i32 88, ; 308
	i32 66, ; 309
	i32 70, ; 310
	i32 27, ; 311
	i32 9, ; 312
	i32 111, ; 313
	i32 46, ; 314
	i32 121, ; 315
	i32 56, ; 316
	i32 137, ; 317
	i32 42, ; 318
	i32 63, ; 319
	i32 135, ; 320
	i32 159, ; 321
	i32 43, ; 322
	i32 58, ; 323
	i32 114, ; 324
	i32 134, ; 325
	i32 22, ; 326
	i32 98, ; 327
	i32 17, ; 328
	i32 49, ; 329
	i32 137, ; 330
	i32 29, ; 331
	i32 108, ; 332
	i32 145, ; 333
	i32 83, ; 334
	i32 110, ; 335
	i32 55, ; 336
	i32 38, ; 337
	i32 143, ; 338
	i32 83 ; 339
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

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
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 0d97e20b84d8e87c3502469ee395805907905fe3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
