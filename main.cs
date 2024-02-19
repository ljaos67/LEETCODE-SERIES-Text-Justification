public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        List<string> result = new List<string>();
        
        int index = 0;
        while(index < words.Length) {
            // Determine how many words fit in the current line
            int totalChars = words[index].Length;
            int last = index + 1;
            while(last < words.Length && totalChars + words[last].Length + (last - index) <= maxWidth) {
                totalChars += words[last].Length;
                last++;
            }
            
            // Build the current line
            StringBuilder builder = new StringBuilder();
            int gaps = last - index - 1; // Number of gaps between words
            // If we're on the last line or if there's only one word in the line, left justify
            if(last == words.Length || gaps == 0) {
                for(int i = index; i < last; i++) {
                    builder.Append(words[i]);
                    if(i < last - 1) builder.Append(" ");
                }
                // Pad the end of the line with spaces
                for(int i = builder.Length; i < maxWidth; i++) {
                    builder.Append(" ");
                }
            } else {
                // Calculate space distribution
                int spaces = (maxWidth - totalChars) / gaps;
                int extraSpaces = (maxWidth - totalChars) % gaps;
                for(int i = index; i < last; i++) {
                    builder.Append(words[i]);
                    if(i < last - 1) {
                        int spaceWidth = spaces + (i - index < extraSpaces ? 1 : 0);
                        builder.Append(' ', spaceWidth);
                    }
                }
            }
            
            result.Add(builder.ToString());
            index = last;
        }
        
        return result;
    }
}
