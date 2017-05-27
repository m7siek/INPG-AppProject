using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Program generujący parę kluczy publicznych  (n,e) oraz prywatnych (n,d) metodą RSA na podstawie załączonej biblioteki liczb pierwszych 
 
     ~Milva

 +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++       
 +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */


namespace ConsoleApplication1
{
    class Program
    {
        public static long Q()
        {
            long q = 0;
            q = Big();

            return q;
        }

        public static long P()
        {
            long p = 0, q = Q();

            while (p == q)
                p = Big();           //  p, q - dwie duże liczby pierwsze o podobnym rozmiarze w bitach losowane metodą "Random"

            return p;
        }

        public static long N()
        {
            long p = P(), q = Q(), n;

            n = p * q;               // pierwsza z pary liczb klucza prywatnego / publicznego

            return n;
        }

        public static long E()
        {
            long e;
            e = Small();
            return e;
        }

        public static long D()
        {
            long k, d, e, p = P(), q = Q();

            //if (p==0||q==0) do dopisania kom. błędu


            k = getIndex();

            e = E();

            d = (1 + k * (p - 1) * (q - 1)) / e;  // druga z pary liczb klucza prywantego
            return d;
        }


        static int getIndex()                           // funkcja losująca liczbę z zakresu 0,50
        {                                               // funkcja losuje indeksy użytych liczb pierwszych
            Random randomIndex = new Random();
            int i;
            i = randomIndex.Next(0, 50);

            return i;
        }


        



        static int Small()
        {
            int[] small;
            small = new int[50];

            int i;
            i = getIndex();
    
            small[0] = 15485863;
            small[1] = 15485867;
            small[2] = 15485917;
            small[3] = 15485927;
            small[4] = 15485933;
            small[5] = 15485941;
            small[6] = 15485959;
            small[7] = 15485989;
            small[8] = 15485993;
            small[9] = 15486013;
            small[10] = 15486041;
            small[11] = 15486047;
            small[12] = 15486059;
            small[13] = 15486071;
            small[14] = 15486101;
            small[15] = 15486139;
            small[16] = 15486157;
            small[17] = 15486173;
            small[18] = 15486181;
            small[19] = 15486193;
            small[20] = 15486209;
            small[21] = 15486221;
            small[22] = 15486227;
            small[23] = 15486241;
            small[24] = 15486257;
            small[25] = 15486259;
            small[26] = 15486277;
            small[27] = 15486281;
            small[28] = 15486283;
            small[29] = 15486287;
            small[30] = 15486347;
            small[31] = 15486421;
            small[32] = 15486433;
            small[33] = 15486437;
            small[34] = 15486451;
            small[35] = 15486469;
            small[36] = 15486481;
            small[37] = 15486487;
            small[38] = 15486491;
            small[39] = 15486511;
            small[40] = 15486517;
            small[41] = 15486533;
            small[42] = 15486557;
            small[43] = 15486571;
            small[44] = 15486589;
            small[45] = 15486649;
            small[46] = 15486671;
            small[47] = 15486673;
            small[48] = 15486703;
            small[49] = 15486707;

            return small[i];

        }


        static int Big()
        {
            int[] big;
            big = new int[50];

            int i;
            i = getIndex();
            
            big[0] = 179424673;
            big[1] = 179424691;
            big[2] = 179424697;
            big[3] = 179424719;
            big[4] = 179424731;
            big[5] = 179424743;
            big[6] = 179424779;
            big[7] = 179424787;
            big[8] = 179424793;
            big[9] = 179424797;
            big[10] = 179424799;
            big[11] = 179424821;
            big[12] = 179424871;
            big[13] = 179424887;
            big[14] = 179424893;
            big[15] = 179424899;
            big[16] = 179424907;
            big[17] = 179424911;
            big[18] = 179424929;
            big[19] = 179424937;
            big[20] = 179424941;
            big[21] = 179424977;
            big[22] = 179424989;
            big[23] = 179425003;
            big[24] = 179425019;
            big[25] = 179425027;
            big[26] = 179425033;
            big[27] = 179425063;
            big[28] = 179425069;
            big[29] = 179425097;
            big[30] = 179425133;
            big[31] = 179425153;
            big[32] = 179425171;
            big[33] = 179425177;
            big[34] = 179425237;
            big[35] = 179425261;
            big[36] = 179425319;
            big[37] = 179425331;
            big[38] = 179425357;
            big[39] = 179425373;
            big[40] = 179425399;
            big[41] = 179425403;
            big[42] = 179425423;
            big[43] = 179425447;
            big[44] = 179425453;
            big[45] = 179425457;
            big[46] = 179425517;
            big[47] = 179425529;
            big[48] = 179425537;
            big[49] = 179425559;


            return big[i];
        }


        }
    }

