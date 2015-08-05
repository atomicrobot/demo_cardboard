using UnityEngine;
using System.Collections.Generic;
using Tacticsoft;
using Tacticsoft.Examples;
using System.IO;
using DetailTableCellNS;
using UnityEngine.UI;

namespace FileTableViewControllerNS
{
    //An example implementation of a class that communicates with a TableView
    public class FileTableViewController : MonoBehaviour, ITableViewDataSource
    {
        public DetailTableCell m_cellPrefab;
        public TableView m_tableView;

		public FileInfo[] info;

        int m_numRows;
        private int m_numInstancesCreated = 0;

		private float scrollingVelocity = 0;
		private float playGazeActivationThreshold = 3.0f;//3 seconds
		private float playGazeActivationTime = 0.0f;
		private bool playIsGazing = false;

        private Dictionary<int, float> m_customRowHeights;

        //Register as the TableView's delegate (required) and data source (optional)
        //to receive the calls
        void Start() {
            m_customRowHeights = new Dictionary<int, float>();
            m_tableView.dataSource = this;

			string path = Directory.GetCurrentDirectory ();
			if (Application.platform == RuntimePlatform.Android)
				path += "/sdcard/media";
			else if (Application.platform == RuntimePlatform.OSXEditor)
				path += "/Nirvana";

			DirectoryInfo dir = new DirectoryInfo(path);
			info = dir.GetFiles("*.mp3");

			m_numRows = info.Length;
        }

		void Awake(){
		}

		void Update(){
			m_tableView.scrollY -= Time.deltaTime * scrollingVelocity;

			if (playIsGazing) {
				playGazeActivationTime += Time.deltaTime;
				if(playGazeActivationTime > playGazeActivationThreshold){
					play ();//run the activation method for the play button
					playGazeActivationTime = 0.0f;
				}
			}
			else{
				playGazeActivationTime = 0.0f;
			}



			//DetailTableCell temp = m_tableView.GetCellAtRow (0) as DetailTableCell;
			//temp.GetComponent<Image> ().color = new Color(0.5f, 0.5f, 1.0f, 0.75f);
			//Debug.Log (m_tableView.visibleRowRange.from );

			Debug.Log (m_tableView.visibleRowRange.count);

			int selectedCellIndex = (int)( m_numRows * (m_tableView.scrollY / m_tableView.scrollableHeight));
			selectedCellIndex = Mathf.Clamp (selectedCellIndex, 0, m_numRows-1);

			for (int i=0;i<m_numRows;i++){
				DetailTableCell temp = m_tableView.GetCellAtRow(i) as DetailTableCell;
				if (temp != null){
					temp.GetComponent<Image>().color = Color.white;
					if (temp.rowNumber == selectedCellIndex)
						temp.GetComponent<Image>().color = new Color(0.5f, 0.5f, 1.0f, 0.5f);
				}
			}
		}

        #region ITableViewDataSource

        //Will be called by the TableView to know how many rows are in this table
        public int GetNumberOfRowsForTableView(TableView tableView) {
            return m_numRows;
        }

        //Will be called by the TableView to know what is the height of each row
        public float GetHeightForRowInTableView(TableView tableView, int row) {
            return GetHeightOfRow(row);
        }

        //Will be called by the TableView when a cell needs to be created for display
        public TableViewCell GetCellForRowInTableView(TableView tableView, int row) {
            DetailTableCell cell = tableView.GetReusableCell(m_cellPrefab.reuseIdentifier) as DetailTableCell;
            if (cell == null) {
                cell = (DetailTableCell)GameObject.Instantiate(m_cellPrefab);
                cell.name = "DynamicHeightCellInstance_" + (++m_numInstancesCreated).ToString();
                cell.onCellHeightChanged.AddListener(OnCellHeightChanged);
            }
            cell.rowNumber = row;
            cell.height = GetHeightOfRow(row);
			cell.m_rowNumberText.text = info [row].Name;
            return cell;
        }

        #endregion

        private float GetHeightOfRow(int row) {
			return 30.0f;
        }

        private void OnCellHeightChanged(int row, float newHeight) {
            if (GetHeightOfRow(row) == newHeight) {
                return;
            }
            //Debug.Log(string.Format("Cell {0} height changed to {1}", row, newHeight));
            m_customRowHeights[row] = newHeight;
            m_tableView.NotifyCellDimensionsChanged(row);
        }

		public void scrollUp(){
			//Debug.Log ("Scroll up");
			scrollingVelocity = 250.0f;
		}

		public void scrollDown(){
			//Debug.Log ("Scroll down");
			scrollingVelocity = -250.0f;
		}

		public void scrollStop(){
			//Debug.Log ("Scroll Stop");
			scrollingVelocity = 0.0f;
		}

		public void playStartGazing(){
			playIsGazing = true;
		}

		public void playStopGazing(){
			playIsGazing = false;
		}

		public void play(){
			//the actual play button activation method
			Debug.Log ("Play");
		}

    }
}
