using System.Windows;
using System.Windows.Shell;
using System.Windows.Threading;

namespace PCL.Core.App;

[LifecycleService(LifecycleState.Running)]
[LifecycleScope("jump-list", "跳转列表", false)]
public partial class JumpListService
{
    [LifecycleStart]
    private static void _Start()
    {
        var app = Lifecycle.CurrentApplication;
        var jumpList = new JumpList();
        jumpList.JumpItems.Add(new JumpTask
        {
            Title = States.Game.SelectedInstance,
            CustomCategory = "最近实例",
            Arguments = $"--launch {States.Game.SelectedInstance}"
        });
        
        // TODO: 添加收藏夹管理
        
        if (app.Dispatcher.CheckAccess())
        {
            JumpList.SetJumpList(app, jumpList);
        }
        else
        {
            app.Dispatcher.BeginInvoke(() => JumpList.SetJumpList(app, jumpList), DispatcherPriority.Normal);
        }
    }
}