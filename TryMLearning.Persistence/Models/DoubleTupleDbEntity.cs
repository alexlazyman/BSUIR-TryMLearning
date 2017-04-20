using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TryMLearning.Model;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Models
{
    [Table("DoubleTuple")]
    public class DoubleTupleDbEntity : IDbEntity, IEnumerable<double?>
    {
        public DoubleTupleDbEntity()
        {
        }

        public DoubleTupleDbEntity(IEnumerable<double> values)
            : this(values.Cast<double?>())
        {
            
        }

        public DoubleTupleDbEntity(IEnumerable<double?> values)
        {
            var takenValues = values.Take(64).ToList();
            takenValues.AddRange(Enumerable.Repeat<double?>(null, 64 - takenValues.Count));

            Value0 = takenValues[0];
            Value1 = takenValues[1];
            Value2 = takenValues[2];
            Value3 = takenValues[3];
            Value4 = takenValues[4];
            Value5 = takenValues[5];
            Value6 = takenValues[6];
            Value7 = takenValues[7];
            Value8 = takenValues[8];
            Value9 = takenValues[9];
            Value10 = takenValues[10];
            Value11 = takenValues[11];
            Value12 = takenValues[12];
            Value13 = takenValues[13];
            Value14 = takenValues[14];
            Value15 = takenValues[15];
            Value16 = takenValues[16];
            Value17 = takenValues[17];
            Value18 = takenValues[18];
            Value19 = takenValues[19];
            Value20 = takenValues[20];
            Value21 = takenValues[21];
            Value22 = takenValues[22];
            Value23 = takenValues[23];
            Value24 = takenValues[24];
            Value25 = takenValues[25];
            Value26 = takenValues[26];
            Value27 = takenValues[27];
            Value28 = takenValues[28];
            Value29 = takenValues[29];
            Value30 = takenValues[30];
            Value31 = takenValues[31];
            Value32 = takenValues[32];
            Value33 = takenValues[33];
            Value34 = takenValues[34];
            Value35 = takenValues[35];
            Value36 = takenValues[36];
            Value37 = takenValues[37];
            Value38 = takenValues[38];
            Value39 = takenValues[39];
            Value40 = takenValues[40];
            Value41 = takenValues[41];
            Value42 = takenValues[42];
            Value43 = takenValues[43];
            Value44 = takenValues[44];
            Value45 = takenValues[45];
            Value46 = takenValues[46];
            Value47 = takenValues[47];
            Value48 = takenValues[48];
            Value49 = takenValues[49];
            Value50 = takenValues[50];
            Value51 = takenValues[51];
            Value52 = takenValues[52];
            Value53 = takenValues[53];
            Value54 = takenValues[54];
            Value55 = takenValues[55];
            Value56 = takenValues[56];
            Value57 = takenValues[57];
            Value58 = takenValues[58];
            Value59 = takenValues[59];
            Value60 = takenValues[60];
            Value61 = takenValues[61];
            Value62 = takenValues[62];
            Value63 = takenValues[63];

            var restValues = values.Skip(64).ToArray();
            if (restValues.Length != 0)
            {
                RelatedDoubleTuple = new DoubleTupleDbEntity(restValues);
            }
        }

        int IDbEntity.Id
        {
            get => DoubleTupleId;
            set => DoubleTupleId = value;
        }

        [Key]
        public int DoubleTupleId { get; set; }

        public int? RelatedDoubleTupleId { get; set; }

        [ForeignKey(nameof(RelatedDoubleTupleId))]
        public DoubleTupleDbEntity RelatedDoubleTuple { get; set; }

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