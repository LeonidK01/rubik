puts "Введите число"
x=ARGV[0].to_i
puts x

sum=0
while x>0
	sum=sum+(x%10)
	x=x/10
end
puts sum