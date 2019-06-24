using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_Euler/*.ASCIIDrawing*/
{
    class ASCIIDrawing
    {

        ASCIIObject _ao;
        internal ASCIIObject ASCIIObject { get => _ao; set => _ao = value; }

        public static bool DrawASCIIObject(ASCIIObject aSCIIObject, int heightOffset = 0,int widthOffset = 0)
        {
            int width = aSCIIObject.objectWidth; // lenght in chars
            int height = aSCIIObject.objectHeight; // height in lines

            int charWidthCount = 0; // internal count of n; reset to 0 every time; charWidthCount%width=0 && charWidthCount!=0
            int lineHeightCount = 0; // internal count of n; increased every time; charWidthCount%width=0 && charWidthCount!=0



            for (int i = 0; i < aSCIIObject.CharacterArray.Length; i++)
            {
                if (charWidthCount % width == 0 && charWidthCount != 0)
                {
                    lineHeightCount += 1; 
                    charWidthCount = 0;
                }
                
                Access.WriteAt(aSCIIObject.CharacterArray[i],widthOffset+charWidthCount,heightOffset+lineHeightCount);

                charWidthCount += 1;
            }

            return true;
        }

        public static void DrawExample()
        {
            #region Simple geometric blob (incomplete as is, easy fix if needed)
            //int tW = 7;
            //int tH = 4;
            //int tOffset = 13;

            //string[] imgA = new string[28];
            //string tryoutString =
            //    "0000000" +
            //    "000/||0" +
            //    "00/0||0" +
            //    "0/00||0"; // 7w*4h
            #endregion

            #region Fill with numbers 0-9
            //int t = 0; // temping for ASCII
            //for (int i = 0; i < imgA.Length; i++)
            //{
            //    imgA[i] = t.ToString();
            //    if (t>9) { t = 0; }
            //    t += 1;
            //}
            #endregion

            #region Fill with Mona Lisa
            // big monay lisa
            //int tW = 60;
            //int tH = 54;
            //int tOffset = 2;
            //string[] imgA = new string[3294];
            //string tryoutString = "8I7III7777777I7$$$$$7$Z$$$$Z$ZZ$$$7I$7Z77$7O$$Z7$$$$$Z$$$$O+87II?7I7777777Z77$777$Z$$$77$$7$$$ZO$$$777ZZ$$Z$$7$7ZZ7Z$$O=8??I777$7II77$777$7II$I77I7777$$$$$$$Z$77$$77$$$Z7$$7777$IO+87?I77I?77I77I7I777$$77I7$77777$$$77$77$777I7$7I7$7$$7Z7$$Z+8IIII7$I7II$I$7I77$II77?II777$7$7I777I$777I7I777$77$7777$7O=8IIIII?I?II7IIIII777I7IIIII??II??7IIII7777$777$IIII77$77$7O+8I????II7III?I?II77I7IIII?8OD8DD8?IIIII7777I7Z7I7$77$77777O=8+I?I?I+?I7?777???7I???IDD$D8DDDD8DI?II7777I77$7I7I$77I777Z=8?????+?I???IIII?III?I8D=,,:~$DDDDDDO??II7II77I7777$7$I$$$Z=8????I??????????II?I?8~:::,::~?Z88DDD+?II?III777I$7I$77$7$Z+8???I???????I+??I???$8~:::::~~?$8D8DDD?IIII?II7777$7$I7II7Z=8?II???????I?+?++?+IZ7:,,:::::~+I8DODD?IIIII?III?II7IIIIII$+8=+??++?I?++??+??+??DZZ$Z:=$$=DZZD8O8D$+?I?III7IIII?IIIII7Z=8++???=O+?+??++??+?~$D~~I,7I=+7?IZO888D+?II??+?+????+=+?++$+8IIZ=?D78~++++?+===8Z8:,:,~=:,~=IO88DDD+?+??+??+?8888ZOO88Z+88888+7O+8$==+=~~=~7OD+::,?Z:~=I$8O888DZ7$ZO$DZ888DO88O8DD8+8DD88D8D888++??$$OOZO8??~:Z=I+I7$OZ888D$88D88DDD88DDDDDD+8Z+DD8DDD8DD8DD8OO8$88$Z$8=,I$I=?7$OOZO8D888888DDDD8DNDDDDI78Z+8DD88DDDDDDDD7?8888$OZZ87:,:+$88O88OO88O88DDDDDDDDDDD+8+88Z?DDDD8DOD8DD8Z7II7DZ78O$D88$O8O8888O888Z888DDDDDDDD8=OO8O$8Z+DD88DDDD8D8DII7?77II78ZODDD+DDOZZZO8O8ZDO88DD8OZO7?$OO$IOOZ+8DD8DD888OD??+?$7II?8OO8DDD==?$$7IZZZZ+OOOO+=+ZOO7ZOOIIZ$OZ+8DO77$OO7Z$8+I+8O8$D88ZD8+:=~++~~==IZI7D8Z$8O8888DZ$OOZ$OZ$+8OZOZ$O$D8I?7=D88ZOD8DO+:::::~::::~7$?$DOOD8D88DZ7Z8I$IZ$7$=8DOOZOO7$$$78O8OOZ88D=7:::::=::~:,:Z$7ODIZ8DO888OOI+IZI7OZ$=88OODOO$Z+?$I??O$O8D:::::::,~:~:,:+Z$8DI$OZ$ODDZZO8ODZ$OOO$+88O8ZO8OZ$ZO+=I?8DD8~,,:,::::,:,,,?$I8~IODD8ZDDD$ZZ$OOO8O8$+D8$Z$Z$ZOZOI?I88D88ZZ:,,::::,,:,,?8=8D8DZO888D8888ZZOZZOOO7+888$77IZOOZOZZ88888ZZD8OO=:,,,,=8D8D8DDDD8DD8DD8D8D$$ZZZZZZ?8Z8777$77+?~OOO8OZ8$D888D8$D?O$7DD8DDD8O888DDDD8DD8Z8ZO$77ZID8ZZ$$8Z8Z$ZOODO88D8O$8DD$$D888DDD8D88ODO8$OZODZ8DD8ZZZ7Z$?+88ZOO$ZOZZZ7Z888ODODOD8888DD888DDDDDZDDDD8$888888D88$77Z7~?I8ZOZZZ8ZI$IO888OZ88DD8D8DD8DO8DDDD88D8D8Z$Z8O88DOZ888+I+7$$I$7++~+I?I?O88ZOOO8DDDDDDDDOO8DD8D8DDD8DO88ZOO888888887III7$I88ZZO$ZOO8888OOOO88DDD88D888DDDD888DDD8O88888D8O88O88O8OOO8O8888D8ZZO88888D8O88DDDDD8DDDDDDDD888DDO88OZ88DO8D8D88OO$78ZZ888D8Z$ZDOD888O888DDDDDDDD8DDDDDDDD888DD88888OOO88DO88Z$$$I$88Z8O88OD8O8OZZ$OO88DDD8DDDDDDDDD8D88DDDDDDD88DDD88DD8ZZ$ZZZ8$OZDD8D88O7D$$ZDI$ODDDDDDDDDDD8DD8DDDD888888DDD88OD8O8ZOO8$88ZO88DD8DZD+8+DDDO::~~==DDDDDDDDD88DDD8888888DDD8Z8DODZO7$78O88DDDD8D88ZZN8OZ:~~=~~~==I+8DDDDDO8D8DDDDDDD8DDDO88ZD$ZOO$88Z8DDDDDDO877887Z?++==~=~~~:~7IZDDDDN$I?8ZZ8D8ZO8DD8ODOOOZ$DD88D8DD8888Z8888ODZD++~~===D+=?OZ+=??~OZZ7ZZ7ZOO8O88ODOZ8$+88OZDD8ODDDODD8O88~=:?I+?=O=,=8ZI7$8?OZ8Z$$Z$8ZD88D88888O8$+88O88Z8ODZ8D88DD=7==~=+7?D++D$I88O87Z$Z$O$8O88OODDDDOOD8O8$+888DO8DD8DDDDDDD+:+=~:+7O77D7$8$7OZOZO88Z8DO8888888Z8D8DO8$+8D88DDDDDDDDDDDD7?~?~$8DD888DDD888D8ZOZD888D8DD88OODD8DD88Z~88DDDDDDDDDDDDD8DOI?N8888D88DDDDDDDDD8888OO888DD8D8DDDDDD8Z=8DDD8DDDDDDDDDDDDDD7$$DDDDDDDDDD8DO88888Z8D8DDDDDD8DDDDDD8O=DDDDDDDDDDDDDDDDDDDDDDDDD8DDDDDDDDD8DDDDDD8DDDDDDDDDDDDDD8O~DDDDD8DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD8DDNDDDDDDDDDDDDDDDD8O~DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD8DDDDDDDDDDD8O~DDDDDD8DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD88~==++====?+III777$$$$$$OOZ7$$77$ZO888O888OOOZZZZ7IIII?+~:,...";
            #endregion

            ///QuestionMark
            ///
            int tW = 40;
            int tH = 34;
            int tOffsetX = 2;
            int tOffsetY = 60;

            string[] imgA = new string[tH*tW];
            string tryoutString = "     ..                                    ,~++?,,,,,,.                           .+I.+:,,,,,,,,                         ,~+  =~::::::::                        ,:=   ~::::::::                        :~.   =~~~~~~~~~                        ~~~    +=======                          =~:~. ..IIII.                           .=~~~:~:::::::,..                         +==:::::::~=~~:.:::.~~~~~:....            +:,,,,::~7?,.:7==~~~~~~~~~~~...          ,,,,,::~:.::,$I====~~=~~~~~~~..         ,,,:::=+=++$7?I$77777?=~~~~~~~ .      ,,,,,::~?====I777.. . . .I=~~~~~~.      ::,,::~=~~~=7$7.          ?=~~~~~.      ::::::~?~~~=Z==?=~       .I~=~~~~:      :::::~=?~~~~~~==I=~      ===~~==,      ::~~~~=++=~~~~~=III   ...7~====??.      ::~==~:~??===~=I7I.  ..+~~~~~~??.       ::~=?~:~+I.,?77?. ..I~~~==~~~?I.        ::~=7:::=+       .~~~==~===II,.        .::~=I:::~=.    =???????II,..          .::~+~:::~:.   .??????II...              :~~?:,::~.    .+????I?.                 ~~+,,::=:     .??????=                  ~=,::~=.     .??????.                  ~=::~=         .+7$I,..                 ,:::~=.........~~~~I~~..            ....::,,,:........??????~~+................,:=:,,,::......?????????...............,+=+7?~:=+,,,,,.,??????I.............................,,,:~IIIII~:,...............................,,,,,......................................................";

            for (int i = 0; i < tryoutString.Length; i++)
            {
                imgA[i] = tryoutString[i].ToString();
            }

            var aObject = new ASCIIObject { CharacterArray = imgA, objectHeight = tH, objectWidth = tW };

            DrawASCIIObject(aObject, tOffsetX, tOffsetY);
            Console.Write("\n");
        }
    }
}
