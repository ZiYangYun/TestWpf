using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EventUIListTest
{
    public class EventListDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultnDataTemplate { get; set; }

        public DataTemplate PartDescDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is EventListBaseModel eventListBaseModel)
            {
                switch (eventListBaseModel.NodeType)
                {
                    case UINodeTypeEnum.none:
                        return DefaultnDataTemplate;
                    case UINodeTypeEnum.question:
                        return PartDescDataTemplate;
                    default:
                        break;
                }
            }
            return DefaultnDataTemplate;
        }
    }

    public enum UINodeTypeEnum
    {
        /// <summary>
        /// 默认为无
        /// </summary>
        none = 0,

        /// <summary>
        /// 大题节点, 表示一道完整的大题
        /// </summary>
        question = 1,
    }
}
