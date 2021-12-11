using System;
using System.Windows.Controls;

namespace SmartLifeManager.Views
{
    public class BaseViewControl : UserControl
    {
        protected ViewChangeParameters _parameter = null;
        public BaseViewControl() { }
        public BaseViewControl(ViewChangeParameters parameter) : base()
        {
            _parameter = parameter;
        }

        public bool AcceptBackButton = false;

        public enum Colors
        {
            DarkGreen,
            LightGreen,
            Yellow,
            Orange,
            Red
        }
        public enum Widgets
        {
            Weather,
            Water,
            Air
        }
        public enum ViewType
        {
            Empty,
            Weather,
            AirCondition,
            WaterCondition,
            TimeTable,
            Settings,
            PlaceHolder,
            WidgetList,
            ConnectedDevices
        }
        public event EventHandler<ViewTypeEventArgs> onViewChangeHandler;


        public class ViewChangeParameters
        {
            public ViewType source;
            public ViewType openView;
            public object openStartParameter = null;
            public object backUpParameter = null;
            public bool saveToBack = false;
        }
        public virtual void onViewChange(ViewType type, bool testPointCreated = false)
        {
            onViewChangeHandler?.Invoke(this, new ViewTypeEventArgs() { Type = type, TestPointCreated = testPointCreated });
        }


        protected void CallChangeViewMainMenu()
        {
            this.onViewChange(ViewType.WidgetList);
        }
        public virtual void prepareToCloseControl() { }
        public virtual void PrepareOnStart() { }

        protected void WaitShow()
        {

        }
    }
    public class ViewTypeEventArgs : EventArgs
    {
        public BaseViewControl.ViewType Type { get; set; } = BaseViewControl.ViewType.Empty;
        public bool TestPointCreated { get; set; } = false;
    }
}
