/*THIS IS A SAMPLE SOURCE-CODE FILE FOR REVIA ASSETS ACQKNOWLEDGE FOR
* UNITY. IT IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
*  THE SOFTWARE.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample4b_OutputDriving_Analog : MonoBehaviour {

    public RAAUOutputChannel outputChannel;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.Label(new Rect(20, 250 + 10, 500, 30), "Analog Output Features Sample");

        if (GUI.Button(new Rect(50, 250 + 30, 200, 30), "Set output to 1.2 Volts"))
        {
            StopAllCoroutines();
            outputChannel.valueAsDouble = 1.2f;
        }
        if (GUI.Button(new Rect(250, 250 + 30, 200, 30), "Set output to 0 Volts"))
        {
            StopAllCoroutines();
            outputChannel.valueAsDouble = 0.0f;
        }
        if (GUI.Button(new Rect(450, 250 + 30, 200, 30), "Send counting signal 0-10V"))
        {
            StartCoroutine(CountingSignalCoroutine());
        }
    }

    float counter = 0;
    IEnumerator CountingSignalCoroutine()
    {
        while (true)
        {
            // Managing a simple counter
            counter += 0.5f;
            if (counter >= 10)
                counter = 0;

            // setting value
            outputChannel.valueAsDouble = counter;

            //Waiting for next incrementation
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
