=begin
print - Выводит строчку без \n
=end
# puts выводит и делает переход на следующию строку
#puts "Рello world_puts"
#print "hello world_print"

# puts "Доброго времени суток #{ARGV[0]}"

# puts String.instance_methods

# puts "--------------------------------"
# puts String.class.instance_methods

puts "Введите ваш любимы язык программирования"

lang= gets.chomp

if lang=="Ruby"
	puts "Вы подлиза"
elsif lang=="Python"
	puts "Вы хороши собой"
elsif lang=="С++"
	puts "Вы выбрали путь ситха"
elsif lang=="С#"
	puts "Это хороший выбор"
elsif lang=="Prolog"
	puts "А ты хорош"
elsif lang=="Kotlin"
	puts "Любишь Андроид ? :("
end

puts "Скоро полюбишь руби" if lang != "Ruby"


case lang
when "Ruby"
	puts "Вы подлиза"
when "Python"
	puts "Вы хороши собой"
end