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

public class Sample1_ConnectorFeatures : MonoBehaviour {

    // We set up a reference to the connector
    public RAAUConnector connector;
    

    // Use this for initialization
    void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Sample code
    private void OnGUI()
    {
        // Display and licence state
        GUI.Label(new Rect(20, 10, 500, 30), "Connector Features Sample (license: " + connector.IsLicenseActive + "), Net requests count= " + connector.GetActiveNetworkRequestCount());

        if (GUI.Button(new Rect(50, 30, 200, 30), "Start Acqusition"))
        {
            // Starting acquisition
            connector.SetAcquisitionActivation(true);
        }
        if (GUI.Button(new Rect(250, 30, 200, 30), "Stop Acqusition"))
        {
            // Stopping acquisition
            connector.SetAcquisitionActivation(false);
        }
        if (GUI.Button(new Rect(450, 30, 200, 30), "Toggle Acqusition"))
        {
            // Toggling acquisition
            connector.ToggleAcquisition();
        }
        if (GUI.Button(new Rect(650, 30, 200, 30), "Load template"))
        {
            // Loading template file
            connector.LoadTemplate("SampleTemplate.gtl");
        }
    }
}
