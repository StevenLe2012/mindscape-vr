using OpenAI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Therapist
{
    namespace OpenAI
    {
        public class TherapistChatGPT : MonoBehaviour
        {
            [SerializeField] private TMP_Text textArea;

            private OpenAIApi openai = new OpenAIApi();

            private string userInput;
            private string Instruction = "Act as a therapist and reply to statements.\nQ: ";

            public async void SendReply(string question)
            {
                Debug.Log("Asking ChatGPT");
                userInput = question;
                Instruction += $"{userInput}\nA: ";
            
                textArea.text = "...";

                // Complete the instruction
                var completionResponse = await openai.CreateCompletion(new CreateCompletionRequest()
                {
                    Prompt = Instruction,
                    Model = "text-davinci-003",
                    MaxTokens = 128
                });

                if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
                {
                    textArea.text = completionResponse.Choices[0].Text;
                    Instruction += $"{completionResponse.Choices[0].Text}\nQ: ";
                    Debug.Log(completionResponse.Choices[0].Text);
                }
                else
                {
                    Debug.LogWarning("No text was generated from this prompt.");
                }
            }
        }
    }
}
