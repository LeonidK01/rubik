# massiv=Array.new()
massiv=[1,2,3,4,5]

def method_sum(mas)
	sum=0
	for i in (0..mas.length-1)
		sum+=mas[i]
	end
	return sum
end

def method_min(mas)
	min=mas[0]
	for i in (1..mas.length-1)
		if mas[i]<min
			min=mas[i]
		end
	end
	return min
end

def method_max(mas)
	max=mas[0]
	for i in (1..mas.length-1)
		if mas[i]>max
			max=mas[i]
		end
	end
	return max
end

def method_proiz(mas)
	proiz=1
	for i in (0..mas.length-1)
		proiz*=mas[i]
	end
	return proiz
	
end

puts(method_sum(massiv))
puts(method_min(massiv))
puts(method_max(massiv))
puts(method_proiz(massiv))