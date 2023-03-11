using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatGPTDemo.Controllers
{
    //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
    //[Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {

        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string outputResult = "";
            var openai = new OpenAI_API.OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionsAsync(completionRequest);

            foreach (var completion in completions.Result.Completions)
            {
                outputResult += completion.Text;
            }

            return Ok(outputResult);
        }
    }
}

