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

public class Sample3_InputReading : MonoBehaviour {

    public RAAUInputChannel inputChannel;

    // Use this for initialization
    void Start () {
		
	}

    public int AnalogChannelNumber = 0;
    public int DigitalChannelNumber = 0;
    public int CalculatedChannelNumber = 0;

    private double analogValue;
    private double digitalValue;
    private double calculatedValue;
    // Update is called once per frame
    void Update () {

        //Reading analog value
        analogValue = -99;
        inputChannel.AnalogRawSamples.TryGetValue(AnalogChannelNumber, out analogValue);

        //Reading digital value
        digitalValue = -99;
        inputChannel.DigitalRawSamples.TryGetValue(DigitalChannelNumber, out digitalValue);

        //Reading calc value
        calculatedValue = -99;
        inputChannel.CalcRawSamples.TryGetValue(CalculatedChannelNumber, out calculatedValue);
    }

    void OnGUI()
    {
        GUIStyle _style = new GUIStyle();
        _style.fontSize = 20;
        _style.normal.textColor = Color.yellow;

        GUI.Label(new Rect(20, 100 + 10, 500, 30), "Input reading Feature Sample");

        GUI.Label(new Rect(50, 100 + 30, 200, 30), "Analog " + AnalogChannelNumber + "= " + analogValue, _style);
        GUI.Label(new Rect(50, 100 + 60, 200, 30), "Digital " + DigitalChannelNumber + "= " + (int)digitalValue, _style);
        // please enable if needed GUI.Label(new Rect(50, 100 + 90, 200, 30), "Calculated " + calculatedValue + "= " + calculatedValue, _style);
    }
}
