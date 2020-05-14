﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slickflow.Engine.Common;
using Slickflow.Engine.Xpdl.Entity;

namespace Slickflow.Engine.Xpdl
{
    /// <summary>
    /// 常用的一些帮助方法
    /// </summary>
    public class XPDLHelper
    {
        /// <summary>
        /// 是否简单组件节点
        /// </summary>
        /// <param name="activityType">活动类型</param>
        /// <returns>判断结果</returns>
        internal static Boolean IsSimpleComponentNode(ActivityTypeEnum activityType)
        {
            if (activityType == ActivityTypeEnum.TaskNode
                    || activityType == ActivityTypeEnum.MultipleInstanceNode
                    || activityType == ActivityTypeEnum.SubProcessNode
                    || activityType == ActivityTypeEnum.ScriptNode
                    || activityType == ActivityTypeEnum.PluginNode
                    || activityType == ActivityTypeEnum.StartNode
                    || activityType == ActivityTypeEnum.EndNode)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 是否复合逻辑处理节点
        /// </summary>
        /// <param name="activityType">活动类型</param>
        /// <returns>判断结果</returns>
        internal static Boolean IsGatewayComponentNode(ActivityTypeEnum activityType)
        {
            return activityType == ActivityTypeEnum.GatewayNode;
        }

        /// <summary>
        /// 是否中间事件处理节点
        /// </summary>
        /// <param name="activityType">活动类型</param>
        /// <returns>判断结果</returns>
        internal static Boolean IsIntermediateEventComponentNode(ActivityTypeEnum activityType)
        {
            return activityType == ActivityTypeEnum.IntermediateNode;
        }

        /// <summary>
        /// 判断是否是中间Timer事件节点
        /// </summary>
        /// <param name="activity">活动节点</param>
        /// <returns>判断结果</returns>
        internal static Boolean IsInterTimerEventComponentNode(ActivityEntity activity)
        {
            return activity.ActivityType == ActivityTypeEnum.IntermediateNode
                    && activity.ActivityTypeDetail.TriggerType == TriggerTypeEnum.Timer;
        }

        /// <summary>
        /// 是否是可办理的任务节点
        /// </summary>
        internal static Boolean IsWorkItem(ActivityTypeEnum activityType)
        {
            if (activityType == ActivityTypeEnum.TaskNode
                || activityType == ActivityTypeEnum.MultipleInstanceNode
                || activityType == ActivityTypeEnum.SubProcessNode)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 根据活动类型获取工作项类型
        /// </summary>
        /// <param name="activityType">活动类型</param>
        /// <returns>工作项类型</returns>
        internal static WorkItemTypeEnum GetWorkItemType(ActivityTypeEnum activityType)
        {
            WorkItemTypeEnum workItemType = WorkItemTypeEnum.NonWorkItem;

            if (activityType == ActivityTypeEnum.TaskNode
                || activityType == ActivityTypeEnum.MultipleInstanceNode
                || activityType == ActivityTypeEnum.SubProcessNode)
            {
                workItemType = WorkItemTypeEnum.IsWorkItem;
            }
            return workItemType;
        }
    }
}
