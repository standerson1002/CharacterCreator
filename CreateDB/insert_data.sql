print '' print '*** using database character_creator ***' print ''
GO
USE [character_creator]
GO


INSERT INTO [dbo].[UserAccount]
		([UserID],[Email])
	VALUES
	('user','user@gmail.com'),
	('friend1','friend1@gmail.com'),
	('friend2','friend2@gmail.com'),
	('friend3','friend3@gmail.com')
GO

/* ======================================================
	print '' print '*** inserting user friend status types ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[UserFriendStatusType]
		([UserFriendStatusID])
	VALUES
	('friend'),
	('pending'),
	('waiting')
GO

/* ======================================================
	print '' print '*** inserting permission types ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[PermissionType]
		([PermissionID],[PermissionDescription])
	VALUES
	('Editor','The ability to edit details about the character.'),
	('Viewer','The ability to view the details of the character.'),
	('No Access','Not permission to view nor edit the details of the character.')
GO

/* ======================================================
	print '' print '*** inserting pre-made skill categories types ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[SkillCategory]
		([SkillCategoryID])
	VALUES
	('Music'),('Art'),('Athlete'),('Computer'),('Smart'),('Math'),('Science'),('Social'),('Unspecified')
GO

/* ======================================================
	print '' print '*** inserting pre-made skill types ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[SkillType]
		([SkillID], [SkillCategory])
	VALUES
	-- Musical
	('Singing','Music'),('Dancing','Music'),
	('Piano','Music'),('Accordian','Music'),('Xylophone','Music'),('Drums','Music'),
	('Acoustic Guitar','Music'),('Bass Guitar','Music'),('Electric Guitar','Music'),('Banjo','Music'),('Ukulele','Music'),
	('Flute','Music'),('Clarinet','Music'),('Oboe','Music'),('Trumpet','Music'),('Trombone','Music'),('Tuba','Music'),('Saxophone','Music'),
	('Recorder','Music'),('Harmonica','Music'),('Panflute','Music'),
	('Cello','Music'),('Violin','Music'),('Viola','Music'),('Bass','Music'),('Harp','Music'),
	-- Artistic
	('Sketching','Art'),('Drawing','Art'),('Painting','Art'),('Oil Pastels','Art'),
	('Scuplting','Art'),('Pottery','Art'),('Print-making','Art'),('Glasswork','Art'),('Ceramics','Art'),
	('Graphic Design','Art'),('Digital Art','Art'),
	-- Athletic
	('Running','Athlete'),('Long Jump','Athlete'),('Swimming','Athlete'),('Rock Climbing','Athlete'),
	('Baseball','Athlete'),('Basketball','Athlete'),('American Football','Athlete'),('Soccer','Athlete'),
	('Cricket','Athlete'),('Rugby','Athlete'),('Golf','Athlete'),('Tennis','Athlete'),('Pickle Ball','Athlete'),
	('Volleyball','Athlete'),('Ping Pong','Athlete'),('Wrestling','Athlete'),('Boxing','Athlete'),('Kickball','Athlete'),
	('Dodgeball','Athlete'),
	-- Computer
	('Programing','Computer'),
	-- Smart
	('Chess','Smart'),('Writing','Smart'),('Business','Smart'),
	-- Math
	('Statistics','Math'),('Algebra','Math'),('Calculus','Math'),
	-- Science
	('Biology','Science'),('Astrometry','Science'),('Geography','Science'),('Geology','Science'),('Genetics','Science'),
	-- Social
	('Acting','Social')
GO

/* ======================================================
	print '' print '*** inserting like dislike types ***'
	GO
  =====================================================*/
INSERT INTO [dbo].[LikeDislikeType]
		([LikeDislikeTypeID])
	VALUES
	('Like'),
	('Dislike')
GO


/* ======================================================
print '' print '*** inserting pre-made traits ***'
GO
  =====================================================*/
INSERT INTO [dbo].[Trait]
		([TraitID], [TraitConnotation], [TraitDescription])
	VALUES
		-- A : Positive Connotation
		('Accessible', 'positive', 'Easy to approach and talk to.'),
		('Active', 'positive', 'Engaging in a lot of physical activities.'),
		('Adaptable', 'positive', 'Able to adjust in a timely fashion to handle change.'),
		('Admirable', 'positive', 'Having approval from others.'),
		('Adventurous', 'positive', 'Willing to engage exciting or risky adventures.'),
		('Agreeable', 'positive', 'Willing to put needs of other people first.'),
		('Alert', 'positive', 'Fully aware and attentive.'),
		('Ambitious', 'positive', 'Having dedication to being successful.'),
		('Amiable', 'positive', 'Having friendly personal qualities.'),
		('Anticipative', 'positive', 'Tending to expect something before it happens.'),
		('Appreciative', 'positive', 'Showing gratitude when shown kindness.'),
		('Articulate', 'positive', 'Speaking clearly with thoughtful sentences.'),
		('Aspiring', 'positive', 'Having ambition to achieve goals.'),
		('Athletic', 'positive', 'Being skillful in physical activities.'),
		('Attractive', 'positive', 'Having a good physical appearance.'),
		-- B : Positive Connotation
		('Balanced', 'positive', 'Having emotional stability and rational thinking, even in difficult situations.'),
		('Benevolent', 'positive', 'Having the desire to help others.'),
		('Brilliant', 'positive', 'Having a high level of intelligence.'),
		-- C : Positive Connotation
		('Calm', 'positive', 'Not showing much distress, excitement, nor anger.'),
		('Capable', 'positive', 'Having the ability to do tasks correctly.'),
		('Captivating', 'positive', 'Being able to keep the attention of others.'),
		('Caring', 'positive', 'Being thoughtful and compassionate towards others.'),
		('Charismatic', 'positive', 'Being socially influential.  '),
		('Charming', 'positive', 'Easy to like.'),
		('Cheerful', 'positive', 'Having a positive and optomistic mindset.'),
		('Clean', 'positive', 'Having good hygiene.'),
		('Clever', 'positive', 'Quickly able to solve problems.'),
		('Compassionate', 'positive', 'Being thoughtful and caring towards others.'),
		('Conciliatory', 'positive', 'Tending to achieve success.'),
		('Confident', 'positive', 'Being sure of oneself.'),
		('Conscientious', 'positive', 'Acting carefully according to morals.'),
		('Considerate', 'positive', 'Thinking about the needs of other people when doing something.'),
		('Contemplative', 'positive', 'Showing thoughtfulness.'),
		('Cooperative', 'positive', 'Easy to work with.'),
		('Courageous', 'positive', 'Showing bravery.'),
		('Courteous', 'positive', 'Having good manners.'),
		('Creative', 'positive', 'Having an impressive artistic ability or imagination.'),
		('Cultured', 'positive', 'Being well-educated and respectful.'),
		-- D : Positive Connotation
		('Debonair', 'positive', 'Having a sophisticated mannerism.'),
		('Decisive', 'positive', 'Having little issue making decisions.'),
		('Dedicated', 'positive', 'Being committed.'),
		('Dignified', 'positive', 'Having a high level mannerism.'),
		('Disciplined', 'positive', 'Being skillful in following rules.'),
		('Discreet', 'positive', 'Speaking respectfully about delicate topics.'),
		('Dutiful', 'positive', 'Performing tasks that are required.'),
		('Dynamic', 'positive', 'Having a lot of energy and ethusiasm.'),
		-- E : Positive Connotation
		('Earnest', 'positive', 'Behaving seriously and with purpose.'),
		('Educated', 'positive', 'Having achieved a high level of education or learning.'),
		('Efficient', 'positive', 'Being productive with tasks.'),
		('Elegant', 'positive', 'Having a tasteful or luxurious sense of style.'),
		('Empathetic', 'positive', 'Relating to other people emotionally.'),
		('Energetic', 'positive', 'Having a lot of energy and stamina.'),
		-- F : Positive Connotation
		('Fair', 'positive', 'Treating people or situations without bias.'),
		('Felicific', 'positive', 'Bring happiness to other people.'),
		('Flexible', 'positive', 'Can easily bend in ways other people might not be able to.'),
		('Focused', 'positive', 'Paying attention and not being prone to distractions.'),
		('Forgiving', 'positive', 'Willing to forgive and not hold grudges.'),
		('Formal', 'positive', 'Behaving in a socially professional manners and words.'),
		('Friendly', 'positive', 'Being kind and open to other people.'),
		-- G : Positive Connotation
		('Generous', 'positive', 'Giving things to other people without expectations of receiving something in return.'),
		('Gentle', 'positive', 'Handling things with care and thought.'),
		('Genuine', 'positive', 'Speaking honestly and personally.'),
		-- H : Positive Connotation
		('Hardworking', 'positive', 'Putting full effort in tasks.'),
		('Healthy', 'positive', 'Having good physical health.'),
		('Helpful', 'positive', 'Successfully assisting others.'),
		('Heroic', 'positive', 'Showing bravery in doing tasks to do good.'),
		('Honest', 'positive', 'Telling the truth and not lying.'),
		('Honorable', 'positive', 'Having a lot of dignity.'),
		('Humble', 'positive', 'Being successful without acting better than others.'),
		('Humorous', 'positive', 'Telling jokes and making other people laugh.'),
		-- I : Positive Connotation
		('Idealistic', 'positive', 'Dreaming of a perfect reality.'),
		('Imaginative', 'positive', 'Having a lot of creativity.'),
		('Incorruptible', 'positive', 'Not betraying values when bribed with fame or money.'),
		('Independent', 'positive', 'Working successfully without the help of other people.'),
		('Individualistic', 'positive', 'Having unique characteristics that are different compared to other people.'),
		('Innovative', 'positive', 'Making or adjusting things to make them better.'),
		('Insightful', 'positive', 'Having a deep understanding of a situation or topic.'),
		('Insouciant', 'positive', 'Showing little to no stress or anxiety.'),
		('Intelligent', 'positive', 'Having a high mental thinking level.'),
		('Intuitive', 'positive', 'Quickly understanding something based on previous experiences or knowledge.'),
		('Invulnerable', 'positive', 'Not capable of receiving injury.'),
		-- J : Positive Connotation
		-- K : Positive Connotation
		('Kind', 'positive', 'Treating people in a flattering or friendly way.'),
		-- L : Positive Connotation
		('Leaderly', 'positive', 'Having a natural ability of leading or being in charge.'),
		('Logical', 'positive', 'Solving problems and handling situations according to thought rather than feelings.'),
		('Lovable', 'positive', 'Easy to love and adore.'),
		('Loyal', 'positive', 'Not going against friends or family.'),
		-- M : Positive Connotation
		('Mature', 'positive', 'Behaving appropriately even in inappropriate situations.'),
		('Methodical', 'positive', 'Behaving in a systematic way.'),
		('Meticulous', 'positive', 'Showing care or interest in the small details.'),
		('Modest', 'positive', 'Behaving without being overly boastful or showy.'),
		-- N : Positive Connotation
		('Neat', 'positive', 'Organizing things in an efficient way.'),
		-- O : Positive Connotation
		('Obedient', 'positive', 'Behaving according to the rules.'),
		('Objective', 'positive', 'Explaing situations without showing bias.'),
		('Observant', 'positive', 'Easiliy picking up on surrounding things.'),
		('Optimistic', 'positive', 'Having a positive outlook on life.'),
		('Organized', 'positive', 'Properly sorting or categorzing things to making finding them easier.'),
		('Original', 'positive', 'Coming up with unique ideas.'),
		-- P : Positive Connotation
		('Pacient', 'positive', 'Waiting without frustration.'),
		('Passionate', 'positive', 'Showing a lot of interest and care.'),
		('Peaceful', 'positive', 'Avoiding violence and aggression.'),
		('Perceptive', 'positive', 'Quickly picking up on things.'),
		('Personable', 'positive', 'Agreeing and pleasing other people.'),
		('Persuasive', 'positive', 'Efficiently convincing people of something.'),
		('Polished', 'positive', 'Behaving professionally and flawlessly with successful results.'),
		('Practical', 'positive', 'Achieving things efficently.'),
		('Precise', 'positive', 'Confirming that things are accurate.'),
		('Professional', 'positive', 'Behaving with social and mental maturity.'),
		('Profound', 'positive', 'Showing a deep level of understanding and insight.'),
		('Pure', 'positive', 'Not being corrupted.'),
		-- Q : Positive Connotation
		-- R : Positive Connotation
		('Rational', 'positive', 'Thinking logically about a situation.'),
		('Realistic', 'positive', 'Thinking in the terms on what is achievable.'),
		('Relaxed', 'positive', 'Maintaing peaceful and calm.'),
		('Reliable', 'positive', 'Always delievering what was required.'),
		('Resourceful', 'positive', 'Able to solve problems with limited tools or material.'),
		('Respectful', 'positive', 'Showing caution and kindness to other people and cultures.'),
		('Responsible', 'positive', 'Proving capable of properly taking care of things.'),
		-- S : Positive Connotation
		('Sane', 'positive', 'Having good mental stability.'),
		('Secure', 'positive', 'Not feeling self doubt.'),
		('Selfless', 'positive', 'Helping others over anything else.'),
		('Sentimental', 'positive', 'Expressing emotions and feelings.'),
		('Skillful', 'positive', 'Displaying and having many talents.'),
		('Sociable', 'positive', 'Agreeing and listening to other people.'),
		('Sophisticated', 'positive', 'Improved through education and experience.'),
		('Steadfast', 'positive', 'Having confidence in faith.'),
		('Strong', 'positive', 'Being physically or mentally capable of difficult things.'),
		('Studious', 'positive', 'Focusing on education and learning.'),
		('Stylish', 'neutral', 'Having a good sense of style or fashion.'),
		('Sauve', 'positive', 'Speaking smoothly in an agreeable way.'),
		('Sweet', 'positive', 'Displaying friendliness and kindness.'),
		('Sympathetic', 'positive', 'Showing care for other people and their problems.'),
		-- T : Positive Connotation
		('Tasteful', 'positive', 'Having a good sense of how something should be.'),
		('Thorough', 'positive', 'Making sure everything is completed properly.'),
		('Tolerant', 'positive', 'Not being bothered by something.'),
		('Trusting', 'positive', 'Willing to have faith in other people.'),
		-- U : Positive Connotation
		('Understanding', 'positive', 'Having consideration for others regarding their struggles.'),
		-- V : Positive Connotation
		('Vivacious', 'positive', 'Behaving in a lively way.'),
		-- W : Positive Connotation
		('Wise', 'positive', 'Having scholarly knowledge.'),
		('Witty', 'positive', 'Having speed saying or doing something in a clever way.'),
		-- X : Positive Connotation
		-- Y : Positive Connotation
		-- Z : Positive Connotation
		
		-- A : Neutral Connotation
		('Ambiguous', 'neutral', 'Not being clear about something that could be interpreted in different ways.'),
		('Androgynous', 'neutral', 'Presenting with a combination of masculine and feminine ways.'),
		('Artful', 'neutral', 'Having skills, especially with deceiving other people.'),
		('Ascetic', 'neutral', 'Abstaining from comforts.'),
		('Authoritarian', 'neutral', 'Enforcing strict obedience to authority.'),
		-- B : Neutral Connotation
		('Busy', 'neutral', 'Having little to no time available.'),
		-- C : Neutral Connotation
		('Casual', 'neutral', 'Behaving informally.'),
		('Cautious', 'neutral', 'Being overly careful.'),
		('Circumspect', 'neutral', 'Unwilling to take risks.'),
		('Competitive', 'neutral', 'Treating everything with intentions to be the best.'),
		('Complex', 'neutral', 'Having many layers.'),
		('Confidential', 'neutral', 'Keeping information secret.'),
		('Conservative', 'neutral', 'Not willing to give too much for something.'),
		('Curious', 'neutral', 'Showing interest.'),
		-- D : Neutral Connotation
		('Determined', 'neutral', 'Not willing to give up.'),
		('Dominating', 'neutral', 'Overly controlling.'),
		('Droll', 'neutral', 'Having curiousity in an amusing way.'),
		-- E : Neutral Connotation
		('Earthy', 'neutral', 'Connecting with nature on a deeper level.'),
		('Emotional', 'neutral', 'Showing a lot of emotion.'),
		('Enigmatic', 'neutral', 'Being hard to understand.'),
		('Experimental', 'neutral', 'Desiring to test and try new things.'),
		-- F : Neutral Connotation
		('Familial', 'neutral', 'Having a focus on family.'),
		('Feminine', 'neutral', 'Presenting in a way that is associated with women.'),
		('Flamboyant', 'neutral', 'Attracting attention due to confidence and style.'),
		('Folksy', 'neutral', 'Behaving according to traditional culture or customs.'),
		('Freewheeling', 'neutral', 'Disregarding the rules or conventions.'),
		('Frugal', 'neutral', 'Not willing to spend too much money.'),
		-- G : Neutral Connotation
		('Guileless', 'neutral', 'Having innoncence.'),
		-- H : Neutral Connotation
		-- I : Neutral Connotation
		('Iconoclastic', 'neutral', 'Showing skepticism of certain beliefs.'),
		('Idiosyncratic', 'neutral', 'Being distinct from others.'),
		('Impassive', 'neutral', 'Not feeling or expressing emotion.'),
		('Impersonal', 'neutral', 'Having no personality.'),
		('Impressionable', 'neutral', 'Easily influenced by others.'),
		('Intense', 'neutral', 'Expressing strong emotions in an extreme way.'),
		('Irreligious', 'neutral', 'Having no religious beliefs.'),
		('Irrelevant', 'neutral', 'Not related to anything important.'),
		-- J : Neutral Connotation
		-- K : Neutral Connotation
		-- L : Neutral Connotation
		('Liberal', 'neutral', 'Willing to give large amounts.'),
		('Loquacious', 'neutral', 'Talking a lot.'),
		-- M : Neutral Connotation
		('Masculine', 'neutral', 'Behaving or looking according to male idealism.'),
		('Mellow', 'neutral', 'Having an easygoing attitude.'),
		('Moralistic', 'neutral', 'Judging everything based on morals.'),
		('Mystical', 'neutral', 'Having a sense of paranormal qualities.'),
		-- N : Neutral Connotation
		('Neutral', 'neutral', 'Not showing strong opinions.'),
		('Noncommital', 'neutral', 'Not wanting to stick to something long term.'),
		-- O : Neutral Connotation
		('Old-fashioned', 'neutral', 'Behaving according to traditional values.'),
		('Ordinary', 'neutral', 'Being overly normal.'),
		('Outspoken', 'neutral', 'Being direct about controversial opinions.'),
		-- P : Neutral Connotation
		('Patriotic', 'neutral', 'Showing pride in a country.'),
		('Perfectionist', 'neutral', 'Needing every task to be done without having anything that can be improved.'),
		('Playful', 'neutral', 'Desiring to have or make things fun.'),
		('Popular', 'neutral', 'Having many friends or fans.'),
		('Predictable', 'neutral', 'Behaving in a way that is expected.'),
		('Preoccupied', 'neutral', 'Distracted by inner dialogue and immersed in thought.'),
		('Private', 'neutral', 'Keeping personal information secret.'),
		('Progressive', 'neutral', 'Favoring new or liberal ideas.'),
		('Promiscuous', 'neutral', 'Behaving in many sexual activites.'),
		('Proud', 'neutral', 'Being confident and satisfied with oneself.'),
		-- Q : Neutral Connotation
		('Quiet', 'neutral', 'Not speaking with low volume or not at all.'),
		('Quirky', 'neutral', 'Having silly or goofy behavior.'),
		-- R : Neutral Connotation
		('Religious', 'neutral', 'Being devoted to faith or religion.'),
		('Reserved', 'neutral', 'Keeping to oneself.'),
		('Restrained', 'neutral', 'Showing moderation with things.'),
		('Romantic', 'neutral', 'Flirting and being thoughtful with someone.'),
		-- S : Neutral Connotation
		('Sarcastic', 'neutral', 'Talking with irony in a mocking way.'),
		('Self-conscious', 'neutral', 'Fully aware of oneself.'),
		('Sensitive', 'neutral', 'Showing social compassion and vulnerability.'),
		('Sensual', 'neutral', 'Feeling gratification in physical senses.'),
		('Serious', 'neutral', 'Not down-playing anything.'),
		('Silly', 'neutral', 'Acting unseriously.'),
		('Simple', 'neutral', 'Lacking complexity.'),
		('Skeptical', 'neutral', 'Doubting things and challenging ideas.'),
		('Solitary', 'neutral', 'Existing alone.'),
		('Spontaneous', 'neutral', 'Behaving in what is desired in the moment.'),
		('Stern', 'neutral', 'Being serious and assertive.'),
		('Stoiid', 'neutral', 'Dependable without showing emotion.'),
		('Strict', 'neutral', 'Harshly demanding obedience.'),
		('Subjective', 'neutral', 'Taking a stance based on personal opinions instead of facts.'),
		('Surprising', 'neutral', 'Not being expected.'),
		-- T : Neutral Connotation
		-- U : Neutral Connotation
		('Unceremonious', 'neutral', 'Being rough or abrupt.'),
		('Unchanging', 'neutral', 'Not changing things.'),
		('Undemanding', 'neutral', 'Not demanding things.'),
		('Unfathomable', 'neutral', 'Hard to believe.'),
		('Unhurried', 'neutral', 'Not feeling rushed.'),
		('Uninhibited', 'neutral', 'Expressing feelings without restraint.'),
		('Unpatriotic', 'neutral', 'Not showing love or support for a country.'),
		('Unpredictable', 'neutral', 'Acting in a way that is hard to expect'),
		('Unsentimental', 'neutral', 'Not influenced by nostalogia or emotions.'),
		-- V : Neutral Connotation
		-- W : Neutral Connotation
		('Wishful', 'neutral', 'Being hopeful about something.'),
		('Whimsical', 'neutral', 'Playful and fanciful.'),
		-- X : Neutral Connotation
		-- Y : Neutral Connotation
		-- Z : Neutral Connotation
		
		-- A : Negative Connotation
		('Abrasive', 'negative', 'Speaking without considering the feelings of others.'),
		('Absentminded', 'negative', 'Easiliy forgetting things.'),
		('Aggressive', 'negative', 'Being quick to anger or violence.'),
		('Agonizing', 'negative', 'Causing mental or physical distress to others.'),
		('Aloof', 'negative', 'Uninterested in others.'),
		('Amoral', 'negative', 'Lacking concern for what is right and what is wrong.'),
		('Antisemitic', 'negative','Having a hatred for Jewish people.'),
		('Antisocial', 'negative', 'Showing no regard towards other people.'),
		('Anxious', 'negative', 'Having intrusive thoughts of distress.'),
		('Apathetic', 'negative', 'Lacking enthusiam or concern.'),
		('Arbitrary', 'negative', 'Behaving randomly and without reason.'),
		('Argumentative', 'negative', 'Tending to start a disagreement.'),
		('Arrogant', 'negative', 'Having an exaggerated sense of importance.'),
		('Artifcial', 'negative', 'Behaving without sincerity'),
		('Assertive', 'negative', 'Being forceful and confident.'),
		-- B : Negative Connotation
		('Barbaric', 'negative', 'Behaving brutally in a primitive way.'),
		('Bewildered', 'negative', 'Showing confusing from things.'),
		('Bizarre', 'negative', 'Being very strange in a shocking way.'),
		('Bland', 'negative', 'Not being exciting.'),
		('Blunt', 'negative', 'Speaking harshly without hesitation.'),
		('Biosterous', 'negative', 'Behaving cheerful in a disruptive way.'),
		('Brittle', 'negative', 'Being physially weak and prone to breaking.'),
		('Brutal', 'negative', 'Being overly harsh or violent.'),
		-- C : Negative Connotation
		('Callous', 'negative', 'Behaving insensitivly cruel towards others.'),
		('Cantakerous', 'negative', 'Being quick to anger and hard to work with.'),
		('Careless', 'negative', 'Acting with disregard towards consequences.'),
		('Childish', 'negative', 'Behaving immaturely.'),
		('Clumsy', 'negative', 'Being without grace, sometimes in a self-harming way.'),
		('Coarse', 'negative', 'Being overly rude or vulgar.'),
		('Complacent', 'negative', 'Overly smuf about achieving success.'),
		('Complaintive', 'negative', 'Showing dissatisfaction in a whiney way.'),
		('Compulsive', 'negative', 'Being unable to resist the urge of doing something.'),
		('Conceited', 'negative', 'Being overly vain and proud of oneself.'),
		('Condemnatory', 'negative', 'Showing strong disapproval.'),
		('Contradictory', 'negative', 'Saying things that go against other things already said.'),
		('Cowardly', 'negative', 'Being overly afraid of things.'),
		('Crafty', 'negative', 'Being misleading to get certain wants.'),
		('Crass', 'negative', 'Lacking mental or emotional intelligence.'),
		('Crazy', 'negative', 'Lacking mental stability.'),
		('Criminal', 'negative', 'Breaking the law.'),
		('Crude', 'negative', 'Being explicit and inappropriate.'),
		('Cruel', 'negative', 'Being overly mean.'),
		('Cynical', 'negative', 'Behaving entirely on self-interest and distrusting others.'),
		-- D : Negative Connotation
		('Deceitful', 'negative', 'Misleading others for self gain or amusment.'),
		('Deceptive', 'negative', 'Displaying misleading intentions.'),
		('Demanding', 'negative', 'Insisting others to meet higher standards.'),
		('Dependent', 'negative', 'Relying fully on someone else and lacking the ability to be independent.'),
		('Desperate', 'negative', 'Showing hopelessness and having little hope of success.'),
		('Destructive', 'negative', 'Causing harm to things and others.'),
		('Devious', 'negative', 'Showing skill in dishonest methods of achievment.'),
		('Difficult', 'negative', 'Hard to deal with.'),
		('Dirty', 'negative', 'Having poor hygiene.'),
		('Disconcerting', 'negative', 'Causing others to feel uncomfortable.'),
		('Discontented', 'negative', 'Unsatisfied or fed up with things.'),
		('Discouraging', 'negative', 'Causing others to lose enthusiasm.'),
		('Discourteous', 'negative', 'Being disrespectful to others.'),
		('Dishonest', 'negative', 'Telling things that are not truthful.'),
		('Disloyal', 'negative', 'Not showing commitment to others.'),
		('Disobedient', 'negative', 'Misbehaving and breaking the rules.'),
		('Disorderly', 'negative', 'Not following laws.'),
		('Disorganized', 'negative', 'Lacking organization'),
		('Disputatious', 'negative', 'Enjoying starting arguements.'),
		('Disrespectful', 'negative', 'Lacking respect and politeness.'),
		('Disruptive', 'negative', 'Causing distractions that have negative impacts.'),
		('Dissolute', 'negative', 'Not caring about morals.'),
		('Distractible', 'negative', 'Easily losing focus or attention.'),
		('Disturbing', 'negative', 'Causing mental discomfort to the point of physical discomfort.'),
		('Dogmatic', 'negative', 'Following rules no matter what they are.'),
		('Dramatic', 'negative', 'Over-reacting to things.'),
		('Dull', 'negative', 'Lacking excitement.'),
		-- E : Negative Connotation
		('Egocentric', 'negative', 'Being overly obsessed with oneself.'),
		('Enevated', 'negative', 'Lacking energy.'),
		('Envious', 'negative', 'Showing jealousy.'),
		('Erratic', 'negative', 'Being mentally unstable or insane.'),
		('Expedient', 'negative', 'Practical but immoral.'),
		('Extreme', 'negative', 'Having an intense personality.'),
		-- F : Negative Connotation
		('Fanatical', 'negative', 'Being overly concerned about something.'),
		('Fanciful', 'negative', 'Having an unrealistic mindset.'),
		('Fatalistic', 'negative', 'Believing that everything is already set to happen and cannot be avoided.'),
		('Fearful', 'negative', 'Being scared of things that are unfamiliar.'),
		('Fickle', 'negative', 'Changing qualities about oneself constantly.'),
		('Fiery', 'negative', 'Having an anger-driven passion.'),
		('Foolish', 'negative', 'Lacking a good sense of judgment.'),
		('Forgetful', 'negative', 'Easily forgetting things.'),
		('Fraudulent', 'negative', 'Lying about having the proper credentials.'),
		('Frightening', 'negative', 'Bring terror to others.'),
		('Frivolous', 'negative', 'Lacking a meaningful purpose.'),
		-- G : Negative Connotation
		('Gloomy', 'negative', 'Having a negative or depressing attitude.'),
		('Greedy', 'negative', 'Behaving selfishly.'),
		('Gullible', 'negative', 'Easily fooled or tricked.'),
		-- H : Negative Connotation
		('Hateful', 'negative', 'Showing hate towards something.'),
		('Haughty', 'negative', 'Having an arrogant sense of superiority.'),
		('Hedonistic', 'negative', 'Addicted to achieving pleasure, even in harmful ways.'),
		('Hesitant', 'negative', 'Being unsure about speaking or acting.'),
		('Hidebound', 'negative', 'Unwilling to change in a way that goes against traditional values.'),
		('Hostile', 'negative', 'Showing aggression or violence.'),
		-- I : Negative Connotation
		('Ignorant', 'negative', 'Being offensive due to not knowing any better.'),
		('Imitative', 'negative', 'Copying other things or people.'),
		('Impatient', 'negative', 'Not being able to wait for a long period of time without giving up or showing frustration.'),
		('Imprudent', 'negative', 'Not caring about consequences.'),
		('Impulsive', 'negative', 'Acting without thinking first.'),
		('Inconsiderate', 'negative', 'Not thinking about others when doing something.'),
		('Incurious', 'negative', 'Lacking interest in everything.'),
		('Indecisive', 'negative', 'Having a hard time making a decision.'),
		('Indulgent', 'negative', 'Doing exactly what is wanted with the desire for pleasure.'),
		('Inert', 'negative', 'Lacking mobility or energy.'),
		('Inhibited', 'negative', 'Being self-conscious to the point of not being able to behave normally.'),
		('Insecure', 'negative', 'Lacking self-confidence and having negative self thoughts.'),
		('Insensitive', 'negative', 'Saying things without considering how they will be precieved.'),
		('Intolerant', 'negative', 'Not being okay with something.'),
		('Irrational', 'negative', 'Thinking without reasonable logic.'),
		('Irresponsible', 'negative', 'Lacking responsibilty or ability to properly do something.'),
		('Irreverent', 'neutral', 'Showing a lack of respect towards serious things.'),
		('Irritable', 'negative', 'Easily frustrated or annoyed.'),
		('Islamaphobic', 'negative','Having a hatred for Muslims.'),
		-- J : Negative Connotation
		-- K : Negative Connotation
		('Kleptomaniac', 'negative', 'Having an addiction to stealing things.'),
		-- L : Negative Connotation
		('Lazy', 'negative', 'Being unwilling to work or put in energy.'),
		('Libidinous', 'negative', 'Showing excessive sexual desire.'),
		-- M : Negative Connotation
		('Malicious', 'negative', 'Having intentions of doing harm.'),
		('Mannerless', 'negative', 'Lacking manners or the ability to be proper.'),
		('Materialistic', 'negative', 'Being overly obsessed with material objects.'),
		('Meddlesome', 'negative', 'Getting enjoyment out of interfering with something.'),
		('Melancholic', 'negative', 'Feeling overly depressed.'),
		('Meretricious', 'negative', 'Having only one positive attribute of being attractive.'),
		('Messy', 'negative', 'Being untidy or dirty.'),
		('Miserable', 'negative', 'Being overly depressed about a situation.'),
		('Misguided', 'negative', 'Having false sense of judgment or reasoning.'),
		('Monstrous', 'negative', 'Acting inhumanly and evil.'),
		('Moody', 'negative', 'Having an unpredictable change in mood.'),
		('Morbid', 'negative', 'Having dark or distrubing interests.'),
		-- N : Negative Connotation
		('Naive', 'negative', 'Lacking experience to properly make judgments or process information.'),
		('Narcissistic', 'negative', 'Being obesessed with oneself.'),
		('Negative', 'negative', 'Having a pessimistic or discouraging attitude or point of view.'),
		('Neglectful', 'negative', 'Not properly taking care of responsibilites.'),
		('Neurotic', 'negative', 'Having challenged mentally.'),
		('Nihilistic', 'negative', 'Not believing in anything, including things that are good or evil.'),
		-- O : Negative Connotation
		('Obnoxious', 'negative', 'Being unpleasant to be around or talk to.'),
		('Obsessive', 'negative', 'Showing an unhealthy interest in something.'),
		('Opinionated', 'negative', 'Acting assertively based on strong opinions.'),
		('Outrageous', 'negative', 'Behaving in an unreasonable way.'),
		('Overbearing', 'negative', 'Being too determined on ordering others in an unpleasant way.'),
		-- P : Negative Connotation
		('Paranoid', 'negative', 'Having obessive thoughts of anxiety.'),
		('Paternalistic', 'negative', 'Tending to make decisions for others for them.'),
		('Perverse', 'negative', 'Insisting on behaving in an unreasonable way.'),
		('Petty', 'negative', 'Holding grudges or seeking revenge for small things.'),
		('Plodding', 'negative', 'Being unexciting.'),
		('Possessive', 'negative', 'Having obesession with control.'),
		('Predatory', 'negative', 'Preying on someone with less power.'),
		('Prejudiced', 'negative', 'Having an unreasonable dislike to a certain community.'),
		('Presumptuous', 'negative', 'Failing to tell what is appropiate in a situation.'),
		('Prim', 'negative', 'Showing disapproval for anything considered improper.'),
		('Procrastinating', 'negative', 'Delaying a task for as long as possible.'),
		('Profligate', 'negative', 'Behaving recklessly in a wasteful way.'),
		('Provocative', 'negative', 'Causing frustration to others.'),
		('Pugnacious', 'negative', 'Showing eagerness to argue or fight.'),
		-- Q : Negative Connotation
		-- R : Negative Connotation
		('Regretful', 'negative', 'Showing regret for past actions.'),
		('Resentful', 'negative', 'Subconscious bitterness at having being treated unfairly.'),
		('Rowdy', 'negative', 'Behaving disorderly and loudly.'),
		-- S : Negative Connotation
		('Sadistic', 'negative', 'Feeling pleasure through the suffering of others.'),
		('Sancitmonious', 'negative', 'Hypocritically pretending to be morally superior.'),
		('Selfish', 'negative', 'Behaving only according to self interest.'),
		('Shy', 'negative', 'Having anxiety around talking to people.'),
		('Sloppy', 'negative', 'Completing tasks without much care nor thought.'),
		('Slow', 'negative', 'Needing more time to do something.'),
		('Sly', 'negative', 'Being misleading or cunning.'),
		('Stubborn', 'negative', 'Being unwilling to cooperate.'),
		('Stupid', 'negative', 'Lacking intelligence.'),
		('Submissive', 'negative', 'Showing no resistance.'),
		('Superficial', 'negative', 'Having a personality that is all surface level.'),
		('Superstitious', 'negative', 'Having irrational beliefs based on superstitions.'),
		('Suspicious', 'negative', 'Behaving in a way that causes others to question the intentions.'),
		-- T : Negative Connotation
		('Tactless', 'negative', 'Showing a lack of sensitivity when dealing with difficult issues.'),
		('Tasteless', 'negative', 'Lacking a sense of style.'),
		('Tense', 'negative', 'Being unable to relax.'),
		('Thoughtless', 'negative', 'Acting without thinking about others or consequences.'),
		('Timid', 'negative', 'Lacking confidence or courage.'),
		('Transphobic', 'negative','Having a hatred for transgender people.'),
		('Treacherous', 'negative', 'Being likely to betray.'),
		('Troublesome', 'negative', 'Tending to behave in bad activites.'),
		-- U : Negative Connotation
		('Unappreciative', 'negative', 'Not being grateful or valuing something.'),
		('Uncharitable', 'negative', 'Lacking sympathy.'),
		('Unconvincing', 'negative', 'Hard to believe.'),
		('Uncooperative', 'negative', 'Resisting work with others.'),
		('Uncreative', 'negative', 'Lacking creative or unique thoughts or ideas.'),
		('Undisciplined', 'negative', 'Lacking discipline or behaving in an uncontrollable way. '),
		('Unfriendly', 'negative', 'Lacking friendliness.'),
		('Ungrateful', 'negative', 'Lacking appreciation for good things, actions, or people.'),
		('Unhealthy', 'negative', 'Behaving in a way that negatively impacts physical health.'),
		('Unlovable', 'negative', 'Being difficult or impossible to love.'),
		('Unreliable', 'negative', 'Not being trustworthy with something.'),
		('Unstable', 'negative', 'Lacking stability mentally.'),
		-- V : Negative Connotation
		('Vacuous', 'negative', 'Lacking intelligence.'),
		('Vague', 'negative', 'Not being specific about something.'),
		('Venal', 'negative', 'Motivated by bribery.'),
		('Vindictive', 'negative', 'Having an unreasonable resire for revenge.'),
		('Violent', 'negative', 'Causing physical harm to things or people.'),
		('Vulnerable', 'negative', 'More likely to be affected by something and having a more severe reaction.'),
		-- W : Negative Connotation
		('Weak', 'negative', 'Having poor physical strength.')
		-- X : Negative Connotation
		-- Y : Negative Connotation
		-- Z : Negative Connotation
GO
