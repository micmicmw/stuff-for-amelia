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

public class Sample4a_OutputDriving_Digital : MonoBehaviour {

    public RAAUOutputChannel outputChannel;
    
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    bool knownState = false;
    private void OnGUI()
    {
        GUI.Label(new Rect(20, 200 + 10, 500, 30), "Digital Output Features Sample. Current:" + knownState);

        if (GUI.Button(new Rect(50, 200 + 30, 200, 30), "Set output to true"))
        {
            knownState = true;
            outputChannel.valueAsBool = knownState;
        }
        if (GUI.Button(new Rect(250, 200 + 30, 200, 30), "Set output to false"))
        {
            knownState = false;
            outputChannel.valueAsBool = knownState;
        }
    }

}
