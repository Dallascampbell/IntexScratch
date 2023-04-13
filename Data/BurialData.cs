using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IntexScratch.Data
{
    public class BurialData
    {
        public float squarenorthsouth { get; set; }
        public float depth { get; set; }
        public float southtohead { get; set; }
        public float squareeastwest { get; set; }
        public float westtohead { get; set; }
        public float westtofeet { get; set; }
        public float southtofeet { get; set; }
        public float northsouth_N { get; set; }
        public float eastwest_E { get; set; }
        public float eastwest_W { get; set; }
        public float adultsubadult_A { get; set; }
        public float adultsubadult_C { get; set; }
        public float preservation_badlypreserved { get; set; }
        public float preservation_deteriorated { get; set; }
        public float preservation_fair { get; set; }
        public float preservation_poorlypreserved { get; set; }
        public float preservation_skeleton { get; set; }
        public float preservation_wellpreserved { get; set; }
        public float preservation_wrapped { get; set; }
        public float wrapping_B { get; set; }
        public float wrapping_H { get; set; }
        public float wrapping_W { get; set; }
        public float haircolor_A { get; set; }
        public float haircolor_B { get; set; }
        public float haircolor_D { get; set; }
        public float haircolor_K { get; set; }
        public float haircolor_R { get; set; }
        public float area_NE { get; set; }
        public float area_NNW { get; set; }
        public float area_NW { get; set; }
        public float area_SE { get; set; }
        public float area_SW { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_N { get; set; }
        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                squarenorthsouth, depth, southtohead, squareeastwest, westtohead,
                westtofeet, southtofeet, northsouth_N, eastwest_E, eastwest_W, adultsubadult_A, adultsubadult_C,
                preservation_badlypreserved, preservation_deteriorated, preservation_fair, preservation_poorlypreserved,
                preservation_skeleton, preservation_wellpreserved, preservation_wrapped, wrapping_B, wrapping_H, wrapping_W,
                haircolor_A, haircolor_B, haircolor_D, haircolor_K, haircolor_R, area_NE, area_NNW, area_NW, area_SE, area_SW, ageatdeath_A,
                ageatdeath_C, ageatdeath_I, ageatdeath_N
            };
            int[] dimensions = new int[] { 1, 36 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
