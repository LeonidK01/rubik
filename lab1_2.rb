
x=ARGV[0].to_i
# puts x

# sum=0
# while x>0
# 	sum=sum+(x%10)
# 	x=x/10
# end
# puts sum
# задание 2
def method_sum(x)
	sum=0
	while x>0
		sum=sum+(x%10)
		x=x/10
	end
	return sum
end

def method_min(x)
	min=x%10
	while x>0
		if x%10<min
			min=x%10
		end
		x=x/10
	end
	return min
end

def method_max(x)
	max=x%10
	while x>0
		if x%10>max
			max=x%10
		end
		x=x/10
	end
	return max
end

puts method_sum(x)
puts method_min(x)
puts method_max(x)