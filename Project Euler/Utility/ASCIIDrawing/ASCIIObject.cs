namespace Project_Euler/*.ASCIIDrawing*/
{
        /// <summary>
        /// widht is span of characters per line
        /// height is number of lines that image will contain
        /// </summary>

    struct ASCIIObject // height and width are in lines and characters
    {       
        public int objectWidth;
        public int objectHeight;
        private string[] characterArray;

        public string title;

        public ASCIIObject(int objectWidth, int objectHeight, string[] characterArray, string title)
        {
            this.objectWidth = objectWidth;
            this.objectHeight = objectHeight;
            this.characterArray = characterArray;
            this.title = title;
        }

        public string[] CharacterArray { get => characterArray; set => characterArray = value; }
    }
}
