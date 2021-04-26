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

public class Sample2_TriggerEventFeatures : MonoBehaviour {

    public RAAUGenericEventSender genericEventSender;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 50 + 10, 500, 30), "Trigger Event Feature Sample");

        if (GUI.Button(new Rect(50, 50 + 30, 200, 30), "Trigger a preconfigured event"))
        {
            /* Here you can trigger any action you wish in the environement*/
            genericEventSender.InsertGlobalEventUsingDefaults();

        }
        if (GUI.Button(new Rect(250, 50 + 30, 200, 30), "Trigger any event"))
        {
            /* Here you can trigger any action you wish in the environement*/
            genericEventSender.InsertGlobalEvent("Second event", RAAcqK.AcqKGlobalEventType.APC);
        }
    }

}
