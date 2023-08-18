namespace LazyEvo.PVEBehavior.Behavior.Conditions
{
    using DevComponents.AdvTree;
    using DevComponents.Editors;
    using LazyLib.Wow;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml;

    internal class BurningEmbersCountCondition : AbstractCondition
    {
        private IntegerInput valueInput;

        public BurningEmbersCountCondition()
        {
            this.Condition = ConditionEnum.LessThan;
            this.Value = 3;
        }

        private void CreateCondition(List<Node> re)
        {
            Node item = new Node {
                Text = "Burning Embers count is "
            };
            item.Nodes.Add(base.CreateRadioButton("LessThan", "Less Than ", "ConditionEnum", this.Condition.Equals(ConditionEnum.LessThan)));
            item.Nodes.Add(base.CreateRadioButton("EqualTo", "Equal To", "ConditionEnum", this.Condition.Equals(ConditionEnum.EqualTo)));
            item.Nodes.Add(base.CreateRadioButton("MoreThan", "More Than", "ConditionEnum", this.Condition.Equals(ConditionEnum.MoreThan)));
            item.Expanded = true;
            re.Add(item);
        }

        private void CreateValue(List<Node> re)
        {
            Node item = new Node {
                Text = "value"
            };
            this.valueInput = new IntegerInput();
            this.valueInput.Value = this.Value;
            this.valueInput.ValueChanged += new EventHandler(this.IntegerInput_ValueChanged);
            item.Nodes.Add(base.CreateControl("Value", "Value", this.valueInput));
            item.Expanded = true;
            re.Add(item);
        }

        public override List<Node> GetNodes()
        {
            List<Node> re = new List<Node>();
            this.CreateCondition(re);
            this.CreateValue(re);
            return re;
        }

        private void IntegerInput_ValueChanged(object sender, EventArgs e)
        {
            this.Value = this.valueInput.Value;
        }

        public override void LoadData(XmlNode xmlNode)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name.Equals("Condition"))
                {
                    this.Condition = (ConditionEnum) Enum.Parse(typeof(ConditionEnum), node.InnerText);
                }
                else if (node.Name.Equals("Value"))
                {
                    this.Value = Convert.ToInt32(node.InnerText);
                }
            }
        }

        public override void NodeClick(Node node)
        {
            if ((node != null) && (node.Tag != null))
            {
                if (node.Tag.Equals("ConditionEnum"))
                {
                    this.Condition = (ConditionEnum) Enum.Parse(typeof(ConditionEnum), node.Name);
                }
                if (node.Tag.Equals("Value"))
                {
                    IntegerInput hostedControl = (IntegerInput) node.HostedControl;
                    this.Value = hostedControl.Value;
                }
            }
        }

        private ConditionEnum Condition { get; set; }

        public override string GetXML
        {
            get
            {
                object obj2 = "<Condition>" + this.Condition + "</Condition>";
                return string.Concat(new object[] { obj2, "<Value>", this.Value, "</Value>" });
            }
        }

        public override bool IsOk
        {
            get
            {
                if (this.Condition.Equals(ConditionEnum.EqualTo))
                {
                    return (LazyLib.Wow.ObjectManager.MyPlayer.BurningEmbers == this.Value);
                }
                if (this.Condition.Equals(ConditionEnum.LessThan))
                {
                    return (LazyLib.Wow.ObjectManager.MyPlayer.BurningEmbers < this.Value);
                }
                return (this.Condition.Equals(ConditionEnum.MoreThan) && (LazyLib.Wow.ObjectManager.MyPlayer.BurningEmbers > this.Value));
            }
        }

        public override string Name
        {
            get
            {
                return "Burning Embers Count";
            }
        }

        private int Value { get; set; }

        public override string XmlName
        {
            get
            {
                return "BurningEmbersCountCondition";
            }
        }
    }
}

