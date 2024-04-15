test
.Net Core 8.0 or above
Mysql 8.0 or above

# Current:
---
bug:
[ ]登出依旧显示signlog
ToDo
[ ]保存到session，但没有app
[ ]统一dao层 type reflection
[x]department p 传输大于等于2的值会死循环
[ ]在前端写一个function，使得调用controller更加简单
现在是
   var a = await Dc.GetOneOwnPropertyAsync<List<Accountinfo>>("Accountinfos", Id);
        Accountinfo? b = a!.FirstOrDefault();
        return b!;

我希望是


   
        return await Dc.GetOneOwnPropertyAsync(2,2,3); //获取两个属性，第三个和第四个 或者第二个和第三个 取决实现方法

使用权限
权限判断
可以在shared里？
---
# handbook
如何添加一个新crud界面

1. 确定模型类
public class TODOClass
{
    public int Id { set; get; }//注意set get
    //property
}

2. 在context中声明
public DbSet<TODOClass> TODOClasses { get; set; }

3. 在侧边栏添加一个导航栏
   <div class="nav-item px-3">
      <NavLink class="nav-link" href="ToDoPage">
            <span class="oi oi-list-rich" aria-hidden="true"></span> To Do 
      </NavLink>
   </div>

4. 添加一个界面
   @page "/ToDoPage"

   List Component todo...

5. 实现DAO层


6. 

---
# Plan
---
1. 注销和登录的实现
   1. 登录判断
      1. 给db写password的种子
      2. 登录匹配password
         1. 要是psw叫null怎么办？如何判断密码不存在？
      3. 注册
   2. 权限
   3. 界面权限判断
2. 签到的实现
3. 实现页面能够添加人员及其相关信息-》完全脱离workbench的可能
4. 
5. 将index显示签到信息，当日课表，进度图
6. 当某个属性里面有多个值时，无法正确显示
7. 莫名其妙的page文件名算类名？
8. 当get 0 时 无法继续，给个refresh
9.  如何确定区分无和正在加载？
10. 结果分页
11. 程序关闭好慢
12. 网页夹加载时initializer加载过于耗时700ms
13. 
14. 完成绩效管理
    1. 考勤
       1. 签到
          1. 增加log
          2. 记录时间
       2. 签退
          1. 记录时间
          2. 提示时常
       3. 
       4. 请假
       5. -课时-
    2. 薪资
       1.  
    完成主页的信息展示功能
    3. 课表
       1. 器材备注
    4. 签到表
    5. 请假表
    6. 
15. 


---

- [x] dept
- [x] w
- [X] 登录 权限管理

- [x] 员工信息档案管理模块
- [x] 组织管理模块
绩效管理模块
人事模块 
- [ ] 工资模块
合同模块
培训模块


---
只搭建框架,不考虑细节

填充优先

---
# 更新日志
log
## 2 19
1. 优化了连接字符串
2. 拆分界面

## 2 20
implement
1. 使用了session store 完成了页面间登录状态验证
2. 搭建了部分签到相关的基础框架
3. 

## 2 21
implement
1. 实现了简单登录逻辑

##
1. 签到系统


## 4/10
bug fix
1. department p 实现的是依据 传入人员 id 查找对应部门，但是实际实现的效果是 依据找到和传入人员id值相同的id部门。修复了逻辑bug
2. 修复了signlogtep无法持续化的问题
3. 添加了thankyou
4. 添加提示 index 无法找到temp
