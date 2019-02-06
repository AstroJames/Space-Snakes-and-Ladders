using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Object_Classes {

   

    /// <summary>
    /// Represents a dice with many face values that can be rolled.
    /// </summary>
    public class Die {
        private const int MIN_FACES = 4;
        private const int DEFAULT_FACE_VALUE = 1;
        private const int SIX_SIDED = 6;


        // Test data
        private static string defaultPath = Environment.CurrentDirectory;
        private static string rollFileName = defaultPath + "\\testrolls.txt";
        private static StreamReader rollFile = new StreamReader(rollFileName);
        private static bool DEBUG = false;


        /// <summary>
        ///  Number of faces on the Die
        /// </summary>
        private int numOfFaces;
        public int NumOfFaces
        {
            get {
                return numOfFaces;
            }
        }//end NumOfFaces


        /// <summary>
        ///  Current value of Die
        /// </summary>
        private int faceValue;
        public int FaceValue
        {
            get {
                return faceValue;
            }
        }//end FaceValue
        

        private int initialFaceValue; //use only in Reset()
    

        // Random seed for random Dice roll
        private static Random random = new Random(100);


        /// <summary>
        ///  Parameterless Constructor
        ///  defaults to a six-sided die with a default initial face value.        
        /// </summary>        
        public Die()
        {
           numOfFaces = SIX_SIDED;
           faceValue = DEFAULT_FACE_VALUE;
        }// end Die


        /// <summary>
        ///  Contructor, Explicitly sets the size of the die. Defaults to a size of
        ///  six if the parameter is invalid.  Face value is randomly chosen
        /// </summary> 
        /// 
        /// <param name="faces">Number of faces on Die</param>
        public Die(int faces)
        {
           
           if (faces < MIN_FACES) {
                numOfFaces = SIX_SIDED;
            } else {
                numOfFaces = faces;
            }

            faceValue = Roll();
	        initialFaceValue = FaceValue;
        }//end Die
        
        
        /// <summary>
        ///  Rolls the die and returns the result.
        /// </summary> 
        /// <remarks> Addendum added  </remarks>
        public int Roll()
        {
            if (!DEBUG)
            {
                faceValue = random.Next(NumOfFaces) + 1;
            }
            else
            {
                faceValue = int.Parse(rollFile.ReadLine());
            }
            return FaceValue;

        }//end Roll


        /// <summary>
        ///  Resets the die face value to its initial value.
        /// </summary>         
        public void Reset()
        {
           faceValue = initialFaceValue;
        }//end Reset


        /// <summary>
        /// Returns a String representation of the dice's attributes.
        /// </summary>
        public override string ToString() {
           string str = string.Format("{0}-Sided die showng {1}", numOfFaces, faceValue);
           
           return str;
       }//end ToString overide


    }// end Die

}
