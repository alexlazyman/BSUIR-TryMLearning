using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TryMLearning.Model
{
    public class DoubleTuple : IEnumerable<double?>
    {
        public DoubleTuple()
        {    
        }

        public DoubleTuple(IEnumerable<double?> values)
        {
            var takenValues = values.Take(60).ToArray();
            var restValues = values.Skip(60).ToArray();

            Value0 = takenValues.Length > 0 ? takenValues[0] : null;
            Value1 = takenValues.Length > 1 ? takenValues[1] : null;
            Value2 = takenValues.Length > 2 ? takenValues[2] : null;
            Value3 = takenValues.Length > 3 ? takenValues[3] : null;
            Value4 = takenValues.Length > 4 ? takenValues[4] : null;
            Value5 = takenValues.Length > 5 ? takenValues[5] : null;
            Value6 = takenValues.Length > 6 ? takenValues[6] : null;
            Value7 = takenValues.Length > 7 ? takenValues[7] : null;
            Value8 = takenValues.Length > 8 ? takenValues[8] : null;
            Value9 = takenValues.Length > 9 ? takenValues[9] : null;
            Value10 = takenValues.Length > 10 ? takenValues[10] : null;
            Value11 = takenValues.Length > 11 ? takenValues[11] : null;
            Value12 = takenValues.Length > 12 ? takenValues[12] : null;
            Value13 = takenValues.Length > 13 ? takenValues[13] : null;
            Value14 = takenValues.Length > 14 ? takenValues[14] : null;
            Value15 = takenValues.Length > 15 ? takenValues[15] : null;
            Value16 = takenValues.Length > 16 ? takenValues[16] : null;
            Value17 = takenValues.Length > 17 ? takenValues[17] : null;
            Value18 = takenValues.Length > 18 ? takenValues[18] : null;
            Value19 = takenValues.Length > 19 ? takenValues[19] : null;
            Value20 = takenValues.Length > 20 ? takenValues[20] : null;
            Value21 = takenValues.Length > 21 ? takenValues[21] : null;
            Value22 = takenValues.Length > 22 ? takenValues[22] : null;
            Value23 = takenValues.Length > 23 ? takenValues[23] : null;
            Value24 = takenValues.Length > 24 ? takenValues[24] : null;
            Value25 = takenValues.Length > 25 ? takenValues[25] : null;
            Value26 = takenValues.Length > 26 ? takenValues[26] : null;
            Value27 = takenValues.Length > 27 ? takenValues[27] : null;
            Value28 = takenValues.Length > 28 ? takenValues[28] : null;
            Value29 = takenValues.Length > 29 ? takenValues[29] : null;
            Value30 = takenValues.Length > 30 ? takenValues[30] : null;
            Value31 = takenValues.Length > 31 ? takenValues[31] : null;
            Value32 = takenValues.Length > 32 ? takenValues[32] : null;
            Value33 = takenValues.Length > 33 ? takenValues[33] : null;
            Value34 = takenValues.Length > 34 ? takenValues[34] : null;
            Value35 = takenValues.Length > 35 ? takenValues[35] : null;
            Value36 = takenValues.Length > 36 ? takenValues[36] : null;
            Value37 = takenValues.Length > 37 ? takenValues[37] : null;
            Value38 = takenValues.Length > 38 ? takenValues[38] : null;
            Value39 = takenValues.Length > 39 ? takenValues[39] : null;
            Value40 = takenValues.Length > 40 ? takenValues[40] : null;
            Value41 = takenValues.Length > 41 ? takenValues[41] : null;
            Value42 = takenValues.Length > 42 ? takenValues[42] : null;
            Value43 = takenValues.Length > 43 ? takenValues[43] : null;
            Value44 = takenValues.Length > 44 ? takenValues[44] : null;
            Value45 = takenValues.Length > 45 ? takenValues[45] : null;
            Value46 = takenValues.Length > 46 ? takenValues[46] : null;
            Value47 = takenValues.Length > 47 ? takenValues[47] : null;
            Value48 = takenValues.Length > 48 ? takenValues[48] : null;
            Value49 = takenValues.Length > 49 ? takenValues[49] : null;
            Value50 = takenValues.Length > 50 ? takenValues[50] : null;
            Value51 = takenValues.Length > 51 ? takenValues[51] : null;
            Value52 = takenValues.Length > 52 ? takenValues[52] : null;
            Value53 = takenValues.Length > 53 ? takenValues[53] : null;
            Value54 = takenValues.Length > 54 ? takenValues[54] : null;
            Value55 = takenValues.Length > 55 ? takenValues[55] : null;
            Value56 = takenValues.Length > 56 ? takenValues[56] : null;
            Value57 = takenValues.Length > 57 ? takenValues[57] : null;
            Value58 = takenValues.Length > 58 ? takenValues[58] : null;
            Value59 = takenValues.Length > 59 ? takenValues[59] : null;
            Value60 = takenValues.Length > 60 ? takenValues[60] : null;
            Value61 = takenValues.Length > 61 ? takenValues[61] : null;
            Value62 = takenValues.Length > 62 ? takenValues[62] : null;
            Value63 = takenValues.Length > 63 ? takenValues[63] : null;

            if (restValues.Length != 0)
            {
                RelatedDoubleTuple = new DoubleTuple(restValues);
            }
        }

        public int DoubleTupleId { get; set; }

        public DoubleTuple RelatedDoubleTuple { get; set; }

        #region Values: Value0 - Value63

        public double? Value0 { get; set; }

        public double? Value1 { get; set; }

        public double? Value2 { get; set; }

        public double? Value3 { get; set; }

        public double? Value4 { get; set; }

        public double? Value5 { get; set; }

        public double? Value6 { get; set; }

        public double? Value7 { get; set; }

        public double? Value8 { get; set; }

        public double? Value9 { get; set; }

        public double? Value10 { get; set; }

        public double? Value11 { get; set; }

        public double? Value12 { get; set; }

        public double? Value13 { get; set; }

        public double? Value14 { get; set; }

        public double? Value15 { get; set; }

        public double? Value16 { get; set; }

        public double? Value17 { get; set; }

        public double? Value18 { get; set; }

        public double? Value19 { get; set; }

        public double? Value20 { get; set; }

        public double? Value21 { get; set; }

        public double? Value22 { get; set; }

        public double? Value23 { get; set; }

        public double? Value24 { get; set; }

        public double? Value25 { get; set; }

        public double? Value26 { get; set; }

        public double? Value27 { get; set; }

        public double? Value28 { get; set; }

        public double? Value29 { get; set; }

        public double? Value30 { get; set; }

        public double? Value31 { get; set; }

        public double? Value32 { get; set; }

        public double? Value33 { get; set; }

        public double? Value34 { get; set; }

        public double? Value35 { get; set; }

        public double? Value36 { get; set; }

        public double? Value37 { get; set; }

        public double? Value38 { get; set; }

        public double? Value39 { get; set; }

        public double? Value40 { get; set; }

        public double? Value41 { get; set; }

        public double? Value42 { get; set; }

        public double? Value43 { get; set; }

        public double? Value44 { get; set; }

        public double? Value45 { get; set; }

        public double? Value46 { get; set; }

        public double? Value47 { get; set; }

        public double? Value48 { get; set; }

        public double? Value49 { get; set; }

        public double? Value50 { get; set; }

        public double? Value51 { get; set; }

        public double? Value52 { get; set; }

        public double? Value53 { get; set; }

        public double? Value54 { get; set; }

        public double? Value55 { get; set; }

        public double? Value56 { get; set; }

        public double? Value57 { get; set; }

        public double? Value58 { get; set; }

        public double? Value59 { get; set; }

        public double? Value60 { get; set; }

        public double? Value61 { get; set; }

        public double? Value62 { get; set; }

        public double? Value63 { get; set; }

        #endregion

        public IEnumerator<double?> GetEnumerator()
        {
            yield return Value0;
            yield return Value1;
            yield return Value2;
            yield return Value3;
            yield return Value4;
            yield return Value5;
            yield return Value6;
            yield return Value7;
            yield return Value8;
            yield return Value9;
            yield return Value10;
            yield return Value11;
            yield return Value12;
            yield return Value13;
            yield return Value14;
            yield return Value15;
            yield return Value16;
            yield return Value17;
            yield return Value18;
            yield return Value19;
            yield return Value20;
            yield return Value21;
            yield return Value22;
            yield return Value23;
            yield return Value24;
            yield return Value25;
            yield return Value26;
            yield return Value27;
            yield return Value28;
            yield return Value29;
            yield return Value30;
            yield return Value31;
            yield return Value32;
            yield return Value33;
            yield return Value34;
            yield return Value35;
            yield return Value36;
            yield return Value37;
            yield return Value38;
            yield return Value39;
            yield return Value40;
            yield return Value41;
            yield return Value42;
            yield return Value43;
            yield return Value44;
            yield return Value45;
            yield return Value46;
            yield return Value47;
            yield return Value48;
            yield return Value49;
            yield return Value50;
            yield return Value51;
            yield return Value52;
            yield return Value53;
            yield return Value54;
            yield return Value55;
            yield return Value56;
            yield return Value57;
            yield return Value58;
            yield return Value59;
            yield return Value60;
            yield return Value61;
            yield return Value62;
            yield return Value63;

            if (RelatedDoubleTuple == null)
            {
                yield break;
            }

            foreach (var value in RelatedDoubleTuple)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}