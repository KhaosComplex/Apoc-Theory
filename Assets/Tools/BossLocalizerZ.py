while True:
	try:
    		mode=float(raw_input('Enter your Z value:'))
	except ValueError:
    		print "Not a number"

	print (mode-40)/10