using Meta.WitAi.TTS.Utilities;
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
            [SerializeField] private TTSSpeaker tTSSpeaker;
            
            [SerializeField] private TMP_Text textArea;

            private OpenAIApi openai = new OpenAIApi();

            private string userInput;
            private string Instruction = "Act as a therapist and respond in less than 30 words. \nQ: ";

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
                    MaxTokens = 360
                });

                if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
                {
                    var chatGPTResponse = completionResponse.Choices[0].Text;
                    textArea.text = chatGPTResponse;
                    tTSSpeaker.Speak(chatGPTResponse);
                    Instruction += $"{chatGPTResponse}\nQ: ";
                    Debug.Log(chatGPTResponse);
                }
                else
                {
                    Debug.LogWarning("No text was generated from this prompt.");
                }
            }
        }
    }
}
