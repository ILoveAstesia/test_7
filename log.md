# 更新日志
log
## 5/15
1. Check Bugs
    1. Therer are some bugs
    2. Searching a object that not exist in db will return a null value and return error to blazor
        1. the reson is that json method GetFromJsonAsync get a unexamed data


## 4/10
bug fix
1. department p 实现的是依据 传入人员 id 查找对应部门，但是实际实现的效果是 依据找到和传入人员id值相同的id部门。修复了逻辑bug
2. 修复了signlogtep无法持续化的问题
3. 添加了thankyou
4. 添加提示 index 无法找到temp


##
1. 签到系统


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
