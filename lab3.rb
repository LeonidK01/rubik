require "yaml"
class Department
    include Comparable 
    public attr_accessor :name
    public attr_reader :number
    def initialize(name,number,duties=[],post_list=Post_list.new())
        self.name= name
        self.number= number
        @duties=duties
        @duties_index_now=0
        @post_list=post_list if Post_list.is_Post?(post_list)
    end
    def number=(val)
      @number=val if Department.number?(val)
    end
    def duties_empty?()
      @duties.size==0
    end
    def to_s()
      return "название:#{self.name}  номер телефона:#{self.number}  обязанности:#{self.duties_read}"
    end
    def duties_add(dutie)
      @duties.push(dutie).uniq!()
    end
    def duties_read()
      sum=","
      @duties.each_with_index do |x,ind| 
        if(ind==@duties_index_now)
          sum+="[#{x}],"
        else
          sum+="#{x},"
        end
      end
      return sum
    end
    def duties_cursor(dutie)
      @duties_index_now = @duties.find_index(dutie) if @duties.find_index(dutie)!= nil
    end
    def duties_cursor_read()
      return @duties[duties_index_now].to_s if  !(self.duties_empty?) 
    end
    def duties_cursor_update(dutie)
      @duties[@duties_index_now]= dutie if !((@duties.include?(dutie)) & (self.duties_empty?))
    end
    def duties_cursor_delete()
      @duties.delete_at(@duties_index_now) if !(self.duties_empty?) 
      @duties_index_now=0
    end
    def Department.number?(number)
      return /\+[0-9]{11}/.match?(number)
    end
    def duties_size()
      @duties.size()
    end
    def <=>(val)
      return 0 if self.name== val.name || self.number== val.number
      return 1 if self.duties_size() > val.duties_size()
      return -1
    end
    def as_hash 
      {
        "name"=> self.name,
        "number"=> self.number,
        "duties"=> @duties,
        "posts"=>@post_list.mass_hash
      }
    end
    def to_s_full()
      self.to_s()+" "+@post_list.to_s()
    end
    def post_cursor=(val)
      @post_list.post_cursor=(val)
    end
    def post_cursor()
      @post_list.post_cursor
    end
    def post_add(val)
      @post_list.post_add(val)
    end
    def post_cursor_update(val)
      @post_list.post_cursor_update(val)
    end
    def post_cursor_delete()
      @post_list.post_cursor_delete()
    end
    def post_read()
      @post_list.post_read()
    end
    def post_free()
      @post_list.select{|x| x.isfree == false}
    end
end
class Salary_constructor
    attr_accessor :salary_param
    def initialize()
      
    end
    def create_salary(hash={})
      self.salary_param=hash
      salary= Fix_sal.new(hash[:fixsal])
      salary=Rub_sal.new(salary,hash[:rub_sal])
      salary=Percent_sal.new(salary,hash[:percent_sal])
      salary=Fine_sal.new(salary,hash[:fine_sal])
      salary=Prem_sal.new(salary,hash[:prem_sal])
      salary
    end
  class Salary
    def get_salary()
      raise NotImplementedError, "#{self.class} has not implemented method '#{__method__}'"
    end
  end
  class Fix_sal < Salary
    def initialize(fixed)
      @fixed =fixed
    end
    def get_salary()
      @fixed
    end
  end
  class Decorator_salary < Salary
    attr_accessor :salary
    def initialize(salary)
      self.salary=salary
    end
    def get_salary
      self.salary.get_salary
    end
  end
  class Rub_sal < Decorator_salary
    def initialize(salary,add_rub)
      @add_rub=add_rub
      super(salary)
    end
    def get_salary()
      self.salary.get_salary + @add_rub
    end
  end
  class Percent_sal < Decorator_salary
    def initialize(salary,percent)
      super(salary)
      @percent=percent
    end
    def get_salary()
      r=rand() 
      salary=self.salary.get_salary
     return salary + salary*@percent/100 if r<0.5
     return salary
    end
  end
  class Fine_sal < Decorator_salary
    def initialize(salary,fine)
      super(salary)
      @fine=fine
    end
    def get_salary()
      self.salary.get_salary -  @fine
    end
  end
  class Prem_sal < Decorator_salary
    def initialize(salary,percent)
      super(salary)
      @percent=percent
    end
    def get_salary()
      salary=self.salary.get_salary
     return salary + salary*@percent/100
    end
  end
  end
  def get_salary(val)
     @salary= @sal_creator.create_salary(val).get_salary
  end
  def set_job_list(val)
    @job_list=val
  end
  def new_jobs(employee,stavka)
    job= Job.new(self,employee,Time.new.inspect,end_work="empty",stawka)
    @job_list.push(job)
  end
  def delete_jobs(employee)
    @job_list.select{|x| x.pasport==employee.pasport}.map{|x| x.end_work=Time.new.inspect}
  end
  
end

class Post_list
  include Enumerable
  def initialize(posts=[])
    @post_list=posts if Post_list.is_Post?(posts) || posts.size==0
    self.post_cursor= nil
  end
  def Post_list.is_Post?(posts)
    c=true
    posts.each{|x| c=false if !x.is_a?(Post)}
    return c
  end
  def each()
    for i in @post_list do
      yield i
    end
  end
  def isempty?()
    @post_list.size==0
  end
  def post_cursor=(val)
    @post_cursor=@post_list.find{|x| x.name== val} if !(self.isempty?)
  end
  def post_cursor()
    return @post_cursor
  end
  def post_add(post)
    @post_list.push(post)  if !(@post_list.include?(post))
  end
  def post_cursor_delete()
    if !(self.isempty?) 
      @post_list.delete(self.post_cursor) 
       self.post_cursor=nil 
    end
  end
  def post_read()
    sum=""
    self.each{|x| sum+=(x.to_s+"\n")}
    return sum
  end
  def post_cursor_read()
    self.post_cursor.to_s
  end
  def post_cursor_update(val)
      @post_list[@post_list.find_index{|x| x==self.post_cursor}]= val
      self.post_cursor= val.name 
  end
  def to_s()
    self.post_read()
  end
  def mass_hash()
    list = []
    @post_list.each{|x| list.push(x.as_hash)}
    return list
  end
  end

  class Employee
    attr_reader :name,:sename,:father_name,:date_burth,:pasport,:phone
    def initialize(name,sename,father_name,date_burth,pasport,phone)
      self.name= name
      self.sename= sename
      self.father_name= father_name
      self.date_burth= date_burth
      self.pasport= pasport
      self.phone= phone 
    end
    def Employee.is_name?(val)
      val.is_a?(String)
    end
    def Employee.is_sename?(val)
      val.is_a?(String)
    end
    def Employee.is_father_name?(val)
      val.is_a?(String)
    end
    def Employee.is_date_burth?(val)
      val.match?(/((0[1-9]{1}|[1-2]{1}[0-9]{1}|3[0-1]{1})\.(0[1-9]{1}|1[0-2]{1})\.(19[0-9]{2}|2[0-9]{3}))/)
    end
    def Employee.is_pasport?(val)
      val.match?(/[0-9]{6}/)
    end
    def Employee.is_phone?(val)
      val.match?(/\+[0-9]{11}/)
    end
    def name=(val)
      @name=val if Employee.is_name?(val)
    end
    def sename=(val)
      @sename=val Employee.is_sename?(val)
    end
    def father_name=(val)
      @father_name=val Employee.is_father_name?(val)
    end
    def date_burth=(val)
      @date_burth =val Employee.is_date_burth?(val)
    end
    def pasport=(val) 
      @pasport =val Employee.is_pasport?(val)
    end
    def phone=(val)
      @phone =val Employee.is_phone?(val)
    end
  end
  class Skilled_employee < Employee
    attr_reader :xp,:description
    def initialize(name,sename,father_name,date_burth,pasport,phone,xp,description)
      self.xp=xp
      self.description=description
      super(name,sename,father_name,date_burth,pasport,phone)
    end
    def xp=(val) 
      @pasport =val Employee.is_xp?(val)
    end
    def description=(val)
      @phone =val Employee.is_description?(val)
    end
    def Employee.is_xp?(val)
      val.is_a?(Integer)
    end
    def Employee.is_description?(val)
      val.is_a?(String)
    end
  end
  
  
  class Employee_list
    include Enumerable
    def initialize(employees=[])
      @employee_list=employees 
    end
  
    def each()
      for i in @employee_list do
        yield i
      end
    end
  
  end
  class Job
    attr_accessor :post,:employee,:start_work,:end_work,:stawka
    def initialize(post,employee,start_work,end_work="empty",stawka)
      self.post= post
      self.employee= employee
      self.start_work= start_work
      self.end_work= end_work
      self.stawka= stawka
    end
    def as_hash
      {
        "order"=> self.order,
        "employee"=> self.employee,
        "start_work"=> self.start_work,
        "end_work"=> self.end_work,
        "stawka"=>self.stawka
      }
    end
  end
  
  class Job_list
    include Enumerable
    def initialize(jobs=[])
      @jobs_list=jobs 
    end
  
    def each()
      for i in @jobs_list do
        yield i
      end
    end
    def mass_hash()
      list = []
      @post_list.each{|x| list.push(x.as_hash)}
      return list
    end
  end
  al={fixsal:200,rub_sal: 30,percent_sal: 10,fine_sal: 100,prem_sal: 20}
post = Post.new("отдел продаж","менеджер",sal,true)
puts(post.salary)
puts(post.as_hash)
puts(post)